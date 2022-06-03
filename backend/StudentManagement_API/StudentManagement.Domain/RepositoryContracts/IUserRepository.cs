using System;
using System.Threading.Tasks;
using StudentManagement.Domain.Entities;

namespace StudentManagement.Domain.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        
    }
}
