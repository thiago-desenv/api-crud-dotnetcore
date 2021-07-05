using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CountyImplementation : BaseRepository<CountyEntity>, ICountyRepository
    {
        private DbSet<CountyEntity> _dataset;
        public CountyImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<CountyEntity>();
        }

        public async Task<CountyEntity> GetCompleteById(Guid id)
        {
            return await _dataset.Include(c => c.UF)
                                  .FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task<CountyEntity> GetCompleteIBGE(int codIBGE)
        {
            return await _dataset.Include(c => c.UF)
                                 .FirstOrDefaultAsync(c => c.CodIBGE.Equals(codIBGE));
        }
    }
}
