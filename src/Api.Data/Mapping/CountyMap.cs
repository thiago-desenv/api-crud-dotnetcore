using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CountyMap : IEntityTypeConfiguration<CountyEntity>
    {
        public void Configure(EntityTypeBuilder<CountyEntity> builder)
        {
            builder.ToTable("County");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.CodIBGE);

            builder.HasOne(u => u.UF)
                    .WithMany(c => c.Countys);
        }
    }
}
