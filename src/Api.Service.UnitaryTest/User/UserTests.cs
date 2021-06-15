using System;
using System.Collections.Generic;
using Api.Domain.DTOS.User;

namespace Api.Service.UnitaryTest.User
{
    public class UserTests
    {
        public static string NomeUsuario { get; set; }
        public static string EmailUsuario { get; set; }
        public static string NomeUsuarioAlterado { get; set; }
        public static string EmailUsuarioAlterado { get; set; }
        public static Guid IdUsuario { get; set; }

        public UserDTO userDTO;
        public UserDTOCreate userDTOCreate;
        public UserDTOCreateResult userDTOCreateResult;
        public UserDTOUpdate userDTOUpdate;
        public UserDTOUpdateResult userDTOUpdateResult;

        public List<UserDTO> lsUserDTO = new List<UserDTO>();

        public UserTests()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                UserDTO userDTOFake = new UserDTO()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                };
                lsUserDTO.Add(userDTOFake);
            }

            userDTO = new UserDTO
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            userDTOCreate = new UserDTOCreate
            {
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            userDTOCreateResult = new UserDTOCreateResult
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario,
                CreateAt = DateTime.Now
            };

            userDTOUpdate = new UserDTOUpdate
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            userDTOUpdateResult = new UserDTOUpdateResult
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                UpdateAt = DateTime.Now
            };
        }
    }
}
