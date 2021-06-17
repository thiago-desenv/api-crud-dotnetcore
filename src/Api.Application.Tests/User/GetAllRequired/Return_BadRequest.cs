using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTOS.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Tests.User.GetAllRequired
{
    public class Return_BadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Teste método GetAll")]
        public async Task Realiza_Teste_Metodo_GetAll()
        {
            List<UserDTO> lsUserDTOMock = new List<UserDTO>();

            for (int i = 0; i < 2; i++)
            {
                lsUserDTOMock.Add(new UserDTO
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.Now
                });
            }

            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(lsUserDTOMock);

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
