using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOS.County;

namespace Api.Domain.Interfaces.Services.County
{
    public interface ICountyService
    {
        Task<CountyDTO> GetTask(Guid id);
        Task<CountyDTOComplete> GetCompleteById(Guid id);
        Task<CountyDTOComplete> GetCompleteByIBGE(int codIBGE);
        Task<IEnumerable<CountyDTO>> GetAll();
        Task<CountyDTOCreateResult> Post(CountyDTOCreate county);
        Task<CountyDTOUpdateResult> Put(CountyDTOUpdate county);
        Task<bool> Delete(Guid id);
    }
}
