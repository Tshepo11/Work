using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Versioning;
using System;
using System.Linq;
using System.Text;
using StudentManagement.Domain;
using StudentManagement.Api.AutoMapperProfiles;
using StudentManagement.Infrastructure.Repository;
using StudentManagement.Domain.RepositoryContracts;
using StudentManagement.Domain.Service.Contracts;
using StudentManagement.Domain.Service;
using StudentManagement.Api.Extensions;

namespace StudentManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("StudentManagementCorsPolicy", options =>
            {
                options.AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.Configure<AppSettings>(Configuration);
            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"]
                    };
                });

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<EntityFrameworkDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DBConnection"]));
            services.AddScoped<IDataContext>(provider => provider.GetService<EntityFrameworkDbContext>());
            #region User

            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IUserRepository, UserRepository>();

            #endregion

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling
                    = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }
                    );

            //configureSwagger
            services.AddVersionedApiExplorer(setupAction =>
            {
                setupAction.GroupNameFormat = "'v'VV";
            });

            services.AddApiVersioning(config =>
            {
                config.ApiVersionReader = new MediaTypeApiVersionReader("v");
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ReportApiVersions = true;
            });

            var apiVersionDescriptionProvider =
                services.BuildServiceProvider()
                        .GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(config =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    config.SwaggerDoc(
                    $"StudentManagementAPISpecification{description.GroupName}",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Student Management API Specification",
                        Version = description.ApiVersion.ToString(),
                        Description = "API to create and Manage Student.",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Email = "Tshepomola12@gmail.com",
                            Name = "Mr Mola Tshepo"
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense
                        {
                            Name = "Mr Mola Tshepo"
                        },
                        TermsOfService = new Uri("http://wwww.linkedin.com/in/mola-tshepo-kingsley")
                    });
                }

                config.DocInclusionPredicate((documentName, apiDescription) =>
                {
                    var actionApiVersionModel = apiDescription.ActionDescriptor
                        .GetApiVersionModel(ApiVersionMapping.Explicit | ApiVersionMapping.Implicit);
                    if (actionApiVersionModel == null)
                    {
                        return true;
                    }

                    if (actionApiVersionModel.DeclaredApiVersions.Any())
                    {
                        return actionApiVersionModel.DeclaredApiVersions.Any(v =>
                        $"StudentManagementAPISpecificationv{v.ToString()}" == documentName);
                    }

                    return actionApiVersionModel.ImplementedApiVersions.Any(v =>
                        $"StudentManagementAPISpecificationv{v.ToString()}" == documentName);
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    setupAction.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                    setupAction.SwaggerEndpoint(
                        $"swagger/StudentManagementAPISpecification{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant()
                        );
                }
                setupAction.RoutePrefix = "";
            });


            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("StudentManagementCorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
