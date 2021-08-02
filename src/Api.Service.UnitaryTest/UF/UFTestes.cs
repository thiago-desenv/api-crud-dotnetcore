using System;
using System.Collections.Generic;
using Api.Domain.DTOS.UF;

namespace Api.Service.UnitaryTest.UF
{
    public class UFTestes
    {
        public static string Name { get; set; }
        public static string UF { get; set; }
        public static Guid IdUF { get; set; }

        public List<UfDTO> ListaUfDTO = new List<UfDTO>();
        public UfDTO UfDTO;

        public UFTestes()
        {
            IdUF = Guid.NewGuid();
            UF = Faker.Address.UsState().Substring(1, 3);
            Name = Faker.Address.UsState();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UfDTO
                {
                    Id = Guid.NewGuid(),
                    UF = Faker.Address.UsState().Substring(1, 3),
                    Name = Faker.Address.UsState()
                };
                ListaUfDTO.Add(dto);
            }

            UfDTO = new UfDTO
            {
                Id = IdUF,
                UF = UF,
                Name = Name
            };
        }

    }
}
