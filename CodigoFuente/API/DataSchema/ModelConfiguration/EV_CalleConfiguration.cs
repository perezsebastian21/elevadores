using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace rsAPIElevador.DataSchema.ModelConfiguration
{
    public class EV_CalleConfiguration : IEntityTypeConfiguration<EV_Calle>
    {
        public void Configure(EntityTypeBuilder<EV_Calle> builder) 
        {
            builder
               .HasKey(k => k.IdCalle);

            builder
                .Property(p => p.IdCalle)
                .ValueGeneratedOnAdd();
        }
    }
}
