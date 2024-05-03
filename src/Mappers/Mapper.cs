using AutoMapper;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
namespace BackendTeamwork.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserReadDto, User>();
        }
    }
}