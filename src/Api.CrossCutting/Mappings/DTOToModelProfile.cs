using Api.Domain.DTOS.CEP;
using Api.Domain.DTOS.County;
using Api.Domain.DTOS.UF;
using Api.Domain.DTOS.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile()
        {
            #region User
            CreateMap<UserModel, UserDTO>().ReverseMap();
            CreateMap<UserModel, UserDTOCreate>().ReverseMap();
            CreateMap<UserModel, UserDTOUpdate>().ReverseMap();
            #endregion

            #region UF
            CreateMap<UFModel, UfDTO>().ReverseMap();
            #endregion

            #region County
            CreateMap<CountyModel, CountyDTO>().ReverseMap();
            CreateMap<CountyModel, CountyDTOCreate>().ReverseMap();
            CreateMap<CountyModel, CountyDTOUpdate>().ReverseMap();
            #endregion

            #region CEP
            CreateMap<CEPModel, CepDTO>().ReverseMap();
            CreateMap<CEPModel, CepDTOCreate>().ReverseMap();
            CreateMap<CEPModel, CepDTOUpdate>().ReverseMap();
            #endregion
        }
    }
}
