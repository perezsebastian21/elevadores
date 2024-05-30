using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.DataSchema
{
    public class EV_RepTecnicoConfiguration : IEntityTypeConfiguration<EV_RepTecnico>
    {
        public void Configure(EntityTypeBuilder<EV_RepTecnico> builder) 
        {
            builder
               .HasKey(k => k.IdRepTecnico);
            
            builder
                .Property(p => p.IdRepTecnico)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(e => e.EV_Calle)
                .WithMany(e => e.EV_RepTecnico)
                .HasForeignKey(e => e.IdCalle)
                .IsRequired(false);

            builder
                .Navigation(e => e.EV_Calle)
                .AutoInclude(true)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder
                .HasMany(e => e.EV_Maquina)
                .WithOne(e => e.EV_RepTecnico)
                .HasForeignKey(e => e.IdMaquina)
                .IsRequired(false);

        }
    }

}