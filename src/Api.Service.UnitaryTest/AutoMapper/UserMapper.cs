using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.DTOS.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.UnitaryTest.AutoMapper
{
    public class UserMapper : BaseTest
    {
        [Fact(DisplayName = "Teste mapeamento modelos")]
        public void Realiza_Teste_Mapeamento_Modelos()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            var entity = Mapper.Map<UserEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Email, model.Email);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            var userDto = Mapper.Map<UserModel>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Name, entity.Name);
            Assert.Equal(userDto.Email, entity.Email);
            Assert.Equal(userDto.CreateAt, entity.CreateAt);
            Assert.Equal(userDto.UpdateAt, entity.UpdateAt);

            List<UserEntity> lsEntity = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                UserEntity itemEntity = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };
                lsEntity.Add(itemEntity);
            }

            var lsDTO = Mapper.Map<List<UserDTO>>(lsEntity);
            Assert.True(lsDTO.Count() == lsEntity.Count());
            for (int i = 0; i < lsDTO.Count(); i++)
            {
                Assert.Equal(lsDTO[i].Id, lsEntity[i].Id);
                Assert.Equal(lsDTO[i].Name, lsEntity[i].Name);
                Assert.Equal(lsDTO[i].Email, lsEntity[i].Email);
                Assert.Equal(lsDTO[i].CreateAt, lsEntity[i].CreateAt);
            }

            var userDTOCreateResult = Mapper.Map<UserDTOCreateResult>(entity);
            Assert.Equal(userDTOCreateResult.Id, entity.Id);
            Assert.Equal(userDTOCreateResult.Name, entity.Name);
            Assert.Equal(userDTOCreateResult.Email, entity.Email);
            Assert.Equal(userDTOCreateResult.CreateAt, entity.CreateAt);

            var userDTOUpdateResult = Mapper.Map<UserDTOUpdateResult>(entity);
            Assert.Equal(userDTOUpdateResult.Id, entity.Id);
            Assert.Equal(userDTOUpdateResult.Name, entity.Name);
            Assert.Equal(userDTOUpdateResult.Email, entity.Email);
            Assert.Equal(userDTOUpdateResult.UpdateAt, entity.UpdateAt);

            var userModel = Mapper.Map<UserModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Name, userDto.Name);
            Assert.Equal(userModel.Email, userDto.Email);
            Assert.Equal(userModel.CreateAt, userDto.CreateAt);
            Assert.Equal(userModel.UpdateAt, userDto.UpdateAt);

            var userDTOCreate = Mapper.Map<UserDTOCreate>(userModel);
            Assert.Equal(userDTOCreate.Name, userModel.Name);
            Assert.Equal(userDTOCreate.Email, userModel.Email);

            var userDTOUpdate = Mapper.Map<UserDTOUpdate>(userModel);
            Assert.Equal(userDTOUpdate.Id, userModel.Id);
            Assert.Equal(userDTOUpdate.Name, userModel.Name);
            Assert.Equal(userDTOUpdate.Email, userModel.Email);
        }
    }
}
