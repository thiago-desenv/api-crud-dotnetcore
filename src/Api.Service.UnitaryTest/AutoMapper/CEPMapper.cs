using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.DTOS.CEP;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.UnitaryTest.AutoMapper
{
    public class CEPMapper : BaseTest
    {
        [Fact(DisplayName = "Teste mapeamento dos modelos de CEP")]
        public void Realiza_Teste_Mapeaamento_Modelos_CEP()
        {
            var model = CriaObjetoModel();

            var listaEntity = new List<CEPEntity>();
            for (int i = 0; i < 5; i++)
                listaEntity.Add(CriaObjetoEntity());

            ModelToEntity(model);
            EntityToDTO(CriaObjetoEntity());
            EntityToDTOComplete(CriaObjetoEntity());
            ListEntityToListDTO(listaEntity);
            CEPEntityToCepDTOCreateResult(CriaObjetoEntity());
            CEPEntityToCepDTOUpdateResult(CriaObjetoEntity());
            CepDTOToCEPModel(CriaObjetoDTO());
            CEPModelToCepDTOCreate(model);
            CEPModelToCepDTOUpdate(model);
        }

        private void ModelToEntity(CEPModel model)
        {
            var entity = Mapper.Map<CEPEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Logradouro, model.Logradouro);
            Assert.Equal(entity.Numero, model.Numero);
            Assert.Equal(entity.CEP, model.CEP);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);
        }

        private void EntityToDTO(CEPEntity entity)
        {
            var dto = Mapper.Map<CepDTO>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Logradouro, entity.Logradouro);
            Assert.Equal(dto.Numero, entity.Numero);
            Assert.Equal(dto.CEP, entity.CEP);
        }

        private void EntityToDTOComplete(CEPEntity entity)
        {
            var dtoComplete = Mapper.Map<CepDTO>(entity);
            Assert.Equal(dtoComplete.Id, entity.Id);
            Assert.Equal(dtoComplete.CEP, entity.CEP);
            Assert.Equal(dtoComplete.Logradouro, entity.Logradouro);
            Assert.Equal(dtoComplete.Numero, entity.Numero);
            Assert.NotNull(dtoComplete.County);
            Assert.NotNull(dtoComplete.County.UF);
        }

        private void ListEntityToListDTO(List<CEPEntity> lsEntity)
        {
            var lsDTO = Mapper.Map<List<CepDTO>>(lsEntity);
            Assert.True(lsDTO.Count == lsEntity.Count);
            for (int i = 0; i < lsDTO.Count; i++)
            {
                Assert.Equal(lsDTO[i].Id, lsEntity[i].Id);
                Assert.Equal(lsDTO[i].CEP, lsEntity[i].CEP);
                Assert.Equal(lsDTO[i].Logradouro, lsEntity[i].Logradouro);
                Assert.Equal(lsDTO[i].Numero, lsEntity[i].Numero);
            }
        }

        private void CEPEntityToCepDTOCreateResult(CEPEntity entity)
        {
            var cepDTOCreateResult = Mapper.Map<CepDTOCreateResult>(entity);
            Assert.Equal(cepDTOCreateResult.Id, entity.Id);
            Assert.Equal(cepDTOCreateResult.Cep, entity.CEP);
            Assert.Equal(cepDTOCreateResult.Logradouro, entity.Logradouro);
            Assert.Equal(cepDTOCreateResult.Numero, entity.Numero);
            Assert.Equal(cepDTOCreateResult.CreateAt, entity.CreateAt);
        }

        private void CEPEntityToCepDTOUpdateResult(CEPEntity entity)
        {
            var dtoUpdateResult = Mapper.Map<CepDTOUpdateResult>(entity);
            Assert.Equal(dtoUpdateResult.Id, entity.Id);
            Assert.Equal(dtoUpdateResult.Cep, entity.CEP);
            Assert.Equal(dtoUpdateResult.Logradouro, entity.Logradouro);
            Assert.Equal(dtoUpdateResult.Numero, entity.Numero);
            Assert.Equal(dtoUpdateResult.UpdateAt, entity.UpdateAt);
        }

        private void CepDTOToCEPModel(CepDTO dto)
        {
            var model = Mapper.Map<CEPModel>(dto);
            Assert.Equal(model.Id, dto.Id);
            Assert.Equal(model.CEP, dto.CEP);
            Assert.Equal(model.Logradouro, dto.Logradouro);
            Assert.Equal(model.Numero, dto.Numero);
        }

        private void CEPModelToCepDTOCreate(CEPModel model)
        {
            var cepDTOCreate = Mapper.Map<CepDTOCreate>(model);
            Assert.Equal(cepDTOCreate.CEP, model.CEP);
            Assert.Equal(cepDTOCreate.Logradouro, model.Logradouro);
            Assert.Equal(cepDTOCreate.Numero, model.Numero);
        }

        private void CEPModelToCepDTOUpdate(CEPModel model)
        {
            var cepDTOUpdate = Mapper.Map<CepDTOUpdate>(model);
            Assert.Equal(cepDTOUpdate.Id, model.Id);
            Assert.Equal(cepDTOUpdate.Cep, model.CEP);
            Assert.Equal(cepDTOUpdate.Logradouro, model.Logradouro);
            Assert.Equal(cepDTOUpdate.Numero, model.Numero);
        }

        private CEPModel CriaObjetoModel()
        {
            return new CEPModel
            {
                Id = Guid.NewGuid(),
                CEP = Faker.RandomNumber.Next(1, 10000).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Numero = "",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                MunicipioId = Guid.NewGuid()
            };
        }

        private CepDTO CriaObjetoDTO()
        {
            return new CepDTO
            {
                Id = Guid.NewGuid(),
                CEP = Faker.RandomNumber.Next(1, 10000).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Numero = "22",
            };
        }

        private CEPEntity CriaObjetoEntity()
        {
            return new CEPEntity
            {
                Id = Guid.NewGuid(),
                CEP = Faker.RandomNumber.Next(1, 10000).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Numero = Faker.RandomNumber.Next(1, 10000).ToString(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                CountyID = Guid.NewGuid(),
                County = new CountyEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UFId = Guid.NewGuid(),
                    UF = new UFEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.UsState(),
                        UF = Faker.Address.UsState().Substring(1, 3)
                    }
                }
            };
        }
    }
}
