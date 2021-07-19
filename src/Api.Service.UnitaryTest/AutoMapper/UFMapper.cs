using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.DTOS.UF;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.UnitaryTest.AutoMapper
{
    public class UFMapper : BaseTest
    {
        [Fact(DisplayName = "Teste mapeamento dos modelos de UF")]
        public void Realiza_Teste_Mapeamento_Modelos_UF()
        {
            var model = CriaObjetoUFModel();

            var listaEntity = new List<UFEntity>();
            for (int i = 0; i < 5; i++)
                listaEntity.Add(CriaObjetoUFEntity());

            ModelToEntity(model);
            EntityToDTO();
            ListEntityToListDTO(listaEntity);
        }

        private void ModelToEntity(UFModel model)
        {
            var entity = Mapper.Map<UFEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.UF, model.UF);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);
        }

        private void EntityToDTO()
        {
            var entity = CriaObjetoUFEntity();

            var userDTO = Mapper.Map<UfDTO>(entity);
            Assert.Equal(userDTO.Id, entity.Id);
            Assert.Equal(userDTO.Name, entity.Name);
            Assert.Equal(userDTO.UF, entity.UF);
        }

        private void ListEntityToListDTO(List<UFEntity> listaEntity)
        {
            var listaDTO = Mapper.Map<List<UfDTO>>(listaEntity);
            Assert.True(listaDTO.Count() == listaEntity.Count());
            for (int i = 0; i < listaDTO.Count(); i++)
            {
                Assert.Equal(listaDTO[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDTO[i].Name, listaEntity[i].Name);
                Assert.Equal(listaDTO[i].UF, listaEntity[i].UF);
            }
        }

        private UFModel CriaObjetoUFModel()
        {
            return new UFModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.UsState(),
                UF = Faker.Address.UsState().Substring(1, 3),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };
        }

        private UFEntity CriaObjetoUFEntity()
        {
            return new UFEntity
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.UsState(),
                UF = Faker.Address.UsState().Substring(1, 3),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };
        }
    }
}
