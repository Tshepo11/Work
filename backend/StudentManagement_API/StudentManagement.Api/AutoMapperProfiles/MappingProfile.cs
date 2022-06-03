using StudentManagement.Domain.Shared;
using StudentManagement.Domain.DTOs;
using StudentManagement.Domain.Entities;
using StudentManagement.Api.Models;

namespace StudentManagement.Api.AutoMapperProfiles
{
    public class MappingProfile : global::AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, UserModel>().ReverseMap();
        }
    }
}
