using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.DataSchema
{
    public class EV_VelocidadesConfiguration : IEntityTypeConfiguration<EV_Velocidades>
    {
        public void Configure(EntityTypeBuilder<EV_Velocidades> builder) 
        {
            builder
               .HasKey(k => k.IdVelocidad);
          
        }
    }

}