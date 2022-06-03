using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagement.Domain.DTOs;

namespace StudentManagement.Domain.Service.Contracts
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(UserDto user);
    }
}
