using System;
using System.Threading.Tasks;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _context;

        public UserRepository(IDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

       

        
    }
}