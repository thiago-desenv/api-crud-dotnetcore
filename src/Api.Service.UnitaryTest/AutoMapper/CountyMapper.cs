using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.DTOS.County;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.UnitaryTest.AutoMapper
{
    public class CountyMapper : BaseTest
    {
        [Fact(DisplayName = "Teste mapeamento modelo de County")]
        public void Realiza_Teste_Modelos_County()
        {
            var model = CriaObjetoModel();

            var listaEntity = new List<CountyEntity>();
            for (int i = 0; i < 5; i++)
                listaEntity.Add(CriaObjetoEntity());

            ModelToEntity(model);
            EntityToDTO(CriaObjetoEntity());
            EntityToDTOComplete(CriaObjetoEntity());
            ListEntityToListDTO(listaEntity);
            EntityTODTOCreateResult(CriaObjetoEntity());
            EntityToUpdateResult(CriaObjetoEntity());
            DTOToModel(CriaObjetoDTO());
            ModelToCountyDTOCreate(model);
            ModelToDTOUpdate(model);
        }

        private void ModelToEntity(CountyModel countyModel)
        {
            var entity = Mapper.Map<CountyEntity>(countyModel);
            Assert.Equal(entity.Id, countyModel.Id);
            Assert.Equal(entity.Name, countyModel.Name);
            Assert.Equal(entity.CodIBGE, countyModel.CodIBGE);
            Assert.Equal(entity.UFId, countyModel.UFId);
            Assert.Equal(entity.CreateAt, countyModel.CreateAt);
            Assert.Equal(entity.UpdateAt, countyModel.UpdateAt);
        }

        private void EntityToDTO(CountyEntity entity)
        {
            var countyDTO = Mapper.Map<CountyDTO>(entity);
            Assert.Equal(countyDTO.Id, entity.Id);
            Assert.Equal(countyDTO.Name, entity.Name);
            Assert.Equal(countyDTO.CodIBGE, entity.CodIBGE);
            Assert.Equal(countyDTO.UFId, entity.UFId);
        }

        private void EntityToDTOComplete(CountyEntity entity)
        {
            var countyDTOComplete = Mapper.Map<CountyDTOComplete>(entity);
            Assert.Equal(countyDTOComplete.Id, entity.Id);
            Assert.Equal(countyDTOComplete.Name, entity.Name);
            Assert.Equal(countyDTOComplete.CodIBGE, entity.CodIBGE);
            Assert.Equal(countyDTOComplete.UFId, entity.UFId);
            Assert.NotNull(countyDTOComplete.UF);
        }

        private void ListEntityToListDTO(List<CountyEntity> listEntity)
        {
            var listDTO = Mapper.Map<List<CountyDTO>>(listEntity);
            Assert.True(listDTO.Count() == listEntity.Count());
            for (int i = 0; i < listDTO.Count(); i++)
            {
                Assert.Equal(listDTO[i].Id, listEntity[i].Id);
                Assert.Equal(listDTO[i].Name, listEntity[i].Name);
                Assert.Equal(listDTO[i].CodIBGE, listEntity[i].CodIBGE);
                Assert.Equal(listDTO[i].UFId, listEntity[i].UFId);
            }
        }

        private void ModelToCountyDTOCreate(CountyModel model)
        {
            var countyDTOCreate = Mapper.Map<CountyModel>(model);
            Assert.Equal(countyDTOCreate.Id, model.Id);
            Assert.Equal(countyDTOCreate.Name, model.Name);
            Assert.Equal(countyDTOCreate.CodIBGE, model.CodIBGE);
            Assert.Equal(countyDTOCreate.UFId, model.UFId);
        }

        private void EntityTODTOCreateResult(CountyEntity entity)
        {
            var countyDTOCreatResult = Mapper.Map<CountyDTOCreateResult>(entity);
            Assert.Equal(countyDTOCreatResult.Id, entity.Id);
            Assert.Equal(countyDTOCreatResult.Name, entity.Name);
            Assert.Equal(countyDTOCreatResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(countyDTOCreatResult.UFId, entity.UFId);
            Assert.Equal(countyDTOCreatResult.CreateAt, entity.CreateAt);
        }

        private void ModelToDTOUpdate(CountyModel model)
        {
            var countyDTOUpdate = Mapper.Map<CountyDTOUpdate>(model);
            Assert.Equal(countyDTOUpdate.Id, model.Id);
            Assert.Equal(countyDTOUpdate.Name, model.Name);
            Assert.Equal(countyDTOUpdate.CodIBGE, model.CodIBGE);
            Assert.Equal(countyDTOUpdate.UFId, model.UFId);
        }

        private void EntityToUpdateResult(CountyEntity entity)
        {
            var countyDTOUpdateResult = Mapper.Map<CountyDTOUpdateResult>(entity);
            Assert.Equal(countyDTOUpdateResult.Id, entity.Id);
            Assert.Equal(countyDTOUpdateResult.Name, entity.Name);
            Assert.Equal(countyDTOUpdateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(countyDTOUpdateResult.UFId, entity.UFId);
            Assert.Equal(countyDTOUpdateResult.UpdateAt, entity.UpdateAt);
        }

        private void DTOToModel(CountyDTO dto)
        {
            var countyModel = Mapper.Map<CountyModel>(dto);
            Assert.Equal(countyModel.Id, dto.Id);
            Assert.Equal(countyModel.Name, dto.Name);
            Assert.Equal(countyModel.CodIBGE, dto.CodIBGE);
            Assert.Equal(countyModel.UFId, dto.UFId);
        }

        private CountyModel CriaObjetoModel()
        {
            return new CountyModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };
        }

        private CountyDTO CriaObjetoDTO()
        {
            return new CountyDTO
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
            };
        }

        private CountyEntity CriaObjetoEntity()
        {
            return new CountyEntity
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                UF = new UFEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    UF = Faker.Address.UsState().Substring(1, 3)
                }
            };
        }
    }
}
