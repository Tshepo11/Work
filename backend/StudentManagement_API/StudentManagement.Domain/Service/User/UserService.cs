using StudentManagement.Domain.Service.Contracts;
using StudentManagement.Domain.RepositoryContracts;
using StudentManagement.Domain.DTOs;
using Microsoft.Extensions.Options;
using System;
using AutoMapper;
using System.Threading.Tasks;
using StudentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo,
            IMapper mapper,
            IOptions<AppSettings> options)
        {
            _appSettings = options.Value ?? throw new ArgumentNullException(nameof(options));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<UserDto> CreateAsync(UserDto user)
        {
            var _user =  _mapper.Map<User>(user);

            await _repo.CreateAsync(_user);
            return user;
        }

    }
}
