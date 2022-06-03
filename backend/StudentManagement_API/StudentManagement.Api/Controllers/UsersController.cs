using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using StudentManagement.Domain.Service.Contracts;
using StudentManagement.Domain.Shared;
using StudentManagement.Domain.DTOs;
using StudentManagement.Api.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using StudentManagement.Domain.RepositoryContracts;
using StudentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using StudentManagement.Domain;
using Microsoft.Extensions.Options;
using System.Text;
using StudentManagement.Domain.Service;
using Microsoft.AspNetCore.Cors;

namespace StudentManagement.Api.Controllers
{
    //[Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [EnableCors("_StudentManagement")]
    public class UsersController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;
        private readonly IDataContext _dataContext;
        private readonly ILogger<UsersController> _logger;
        private readonly AutoMapper.IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(
            IConfiguration configuration,
            IDataContext dataContext,
            ILogger<UsersController> logger,
            AutoMapper.IMapper mapper,
            IOptions<AppSettings> options,
            IUserService userService)
        {
            _appSettings = options.Value;
            _configuration = configuration;
            _dataContext = dataContext;
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
        }

       [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel model)
        {
            var userDto = await _userService
                .CreateAsync(_mapper.Map<UserDto>(model));

            return Ok("Saved student Successfully");
        }
    }
}
