using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOS.UF;

namespace Api.Domain.Interfaces.Services.UF
{
    public interface IUFService
    {
        Task<UfDTO> GetTask(Guid id);
        Task<IEnumerable<UfDTO>> GetAll();
    }
}
