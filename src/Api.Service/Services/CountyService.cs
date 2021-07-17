using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOS.County;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.County;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class CountyService : ICountyService
    {
        private ICountyRepository _repository;
        private IMapper _mapper;

        public CountyService(ICountyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CountyDTO>> GetAll()
        {
            var listEntity = await _repository.SelectAllAsync();
            return _mapper.Map<IEnumerable<CountyDTO>>(listEntity);
        }

        public async Task<CountyDTOComplete> GetCompleteByIBGE(int codIBGE)
        {
            var entity = await _repository.GetCompleteIBGE(codIBGE);
            return _mapper.Map<CountyDTOComplete>(entity);
        }

        public async Task<CountyDTOComplete> GetCompleteById(Guid id)
        {
            var entity = await _repository.GetCompleteById(id);
            return _mapper.Map<CountyDTOComplete>(entity);
        }

        public async Task<CountyDTO> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CountyDTO>(entity);
        }

        public async Task<CountyDTOCreateResult> Post(CountyDTOCreate county)
        {
            var model = _mapper.Map<CountyModel>(county);
            var entity = _mapper.Map<CountyEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CountyDTOCreateResult>(result);
        }

        public async Task<CountyDTOUpdateResult> Put(CountyDTOUpdate county)
        {
            var model = _mapper.Map<CountyModel>(county);
            var entity = _mapper.Map<CountyEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<CountyDTOUpdateResult>(result);
        }
    }
}
