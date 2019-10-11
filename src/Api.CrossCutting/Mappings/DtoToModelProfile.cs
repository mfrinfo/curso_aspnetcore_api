using Api.Domain.Dtos;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            //        Source     Destination     
            CreateMap<UserModel, UserDto>()
               .ReverseMap();
        }
    }
}
