using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOS.UF;

namespace Api.Domain.Interfaces.Services.UF
{
    public interface IUFService
    {
        Task<UfDTO> Get(Guid id);
        Task<IEnumerable<UfDTO>> GetAll();
    }
}
