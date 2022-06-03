using System;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.RepositoryContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Infrastructure.Repository
{
    public partial class EntityFrameworkDbContext : DbContext, IDataContext
    {
        public EntityFrameworkDbContext(DbContextOptions<EntityFrameworkDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
  
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasQueryFilter(e => e.DeletedAt == null);
                entity.HasIndex(e => new { e.Name, e.DeletedAt }).IsUnique();

            });

        }
    }
}