using Api.Domain.DTOS.CEP;
using Api.Domain.DTOS.County;
using Api.Domain.DTOS.UF;
using Api.Domain.DTOS.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<UserDTO, UserEntity>().ReverseMap();
            CreateMap<UserDTOCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDTOUpdateResult, UserEntity>().ReverseMap();

            CreateMap<UfDTO, UFEntity>().ReverseMap();

            CreateMap<CountyDTO, CountyEntity>().ReverseMap();
            CreateMap<CountyDTOComplete, CountyEntity>().ReverseMap();
            CreateMap<CountyDTOCreateResult, CountyEntity>().ReverseMap();
            CreateMap<CountyDTOUpdateResult, CountyEntity>().ReverseMap();

            CreateMap<CepDTO, CEPEntity>().ReverseMap();
            CreateMap<CepDTOCreateResult, CEPEntity>().ReverseMap();
            CreateMap<CepDTOUpdateResult, CEPEntity>().ReverseMap();
        }
    }
}
