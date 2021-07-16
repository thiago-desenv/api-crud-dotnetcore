using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>().ReverseMap();
            CreateMap<UFModel, UFEntity>().ReverseMap();
            CreateMap<CountyModel, CountyEntity>().ReverseMap();
            CreateMap<CEPModel, CEPEntity>().ReverseMap();
        }
    }
}
