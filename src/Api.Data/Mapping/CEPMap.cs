using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CEPMap : IEntityTypeConfiguration<CEPEntity>
    {
        public void Configure(EntityTypeBuilder<CEPEntity> builder)
        {
            builder.ToTable("CEP");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.CEP);

            builder.HasOne(c => c.County)
                    .WithMany(c => c.CEPs);
        }
    }
}
