using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOS.UF;
using Api.Domain.Interfaces.Services.UF;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class UFServices : IUFService
    {
        private IUFRepository _repository;
        private readonly IMapper _mapper;

        public UFServices(IUFRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UfDTO> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UfDTO>(entity);
        }

        public async Task<IEnumerable<UfDTO>> GetAll()
        {
            var listEntity = await _repository.SelectAllAsync();
            return _mapper.Map<IEnumerable<UfDTO>>(listEntity);
        }
    }
}
