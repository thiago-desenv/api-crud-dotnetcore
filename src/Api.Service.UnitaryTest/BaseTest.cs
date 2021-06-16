using System;
using Api.CrossCutting.Mappings;
using AutoMapper;

namespace Api.Service.UnitaryTest
{
    public abstract class BaseTest
    {
        public IMapper Mapper { get; set; }

        public BaseTest()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToEntityProfile());
                cfg.AddProfile(new DTOToModelProfile());
                cfg.AddProfile(new EntityToDTOProfile());
            }).CreateMapper();
        }

        public void Dispose()
        {
        }
    }
}
