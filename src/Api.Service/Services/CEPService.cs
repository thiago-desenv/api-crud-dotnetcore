using System;
using System.Threading.Tasks;
using Api.Domain.DTOS.CEP;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.CEP;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class CEPService : ICEPService
    {
        private ICEPRepository _repository;
        private IMapper _mapper;

        public CEPService(ICEPRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CepDTO> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CepDTO>(entity);
        }

        public async Task<CepDTO> Get(string cep)
        {
            var entity = await _repository.SelectAsync(cep);
            return _mapper.Map<CepDTO>(entity);
        }

        public async Task<CepDTOCreateResult> Post(CepDTOCreate cep)
        {
            var model = _mapper.Map<CEPModel>(cep);
            var entity = _mapper.Map<CEPEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CepDTOCreateResult>(result);
        }

        public async Task<CepDTOUpdateResult> Put(CepDTOUpdateResult cep)
        {
            var model = _mapper.Map<CEPModel>(cep);
            var entity = _mapper.Map<CEPEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<CepDTOUpdateResult>(result);
        }
    }
}
