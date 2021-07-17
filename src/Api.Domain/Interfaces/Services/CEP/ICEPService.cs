using System;
using System.Threading.Tasks;
using Api.Domain.DTOS.CEP;

namespace Api.Domain.Interfaces.Services.CEP
{
    public interface ICEPService
    {
        Task<CepDTO> Get(Guid id);
        Task<CepDTO> Get(string cep);
        Task<CepDTOCreateResult> Post(CepDTOCreate cep);
        Task<CepDTOUpdateResult> Put(CepDTOUpdateResult cep);
        Task<bool> Delete(Guid id);
    }
}
