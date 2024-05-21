using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using rsAPIElevador.DataSchema.ModelConfiguration;

namespace rsAPIElevador.DataSchema
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

            //this.ChangeTracker.LazyLoadingEnabled = false;
            //this.Configuration.LazyLoadingEnabled = false;
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<EJ_Usuario> EJ_Usuarios { get; set; }
        public DbSet<EV_Velocidades> EV_Velocidades { get; set; }
        public DbSet<EV_TipoEquipamiento> EV_TipoEquipamiento { get; set; }
        public virtual DbSet<EV_Seguro> EV_Seguro { get; set; }
        public DbSet<EV_TipoObra> EV_TipoObra { get; set; }
        public DbSet<EV_RepTecnico> EV_RepTecnico { get; set; }
        public DbSet<EV_Administracion> EV_Administracion { get; set; }
        public DbSet<EV_Conservadora> EV_Conservadora { get; set; }
        public DbSet<EV_Obra> EV_Obra { get; set; }
        public DbSet<EV_Maquina> EV_Maquina { get; set; }
        public DbSet<EV_Persona> EV_Persona { get; set; }
        public DbSet<EV_Calle> EV_Calle { get; set; }

        //public DbSet<EV_ConservadoraEV_RepTecnico> EV_ConservadoraEV_RepTecnico { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EJ_UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EV_VelocidadesConfiguration());
            modelBuilder.ApplyConfiguration(new EV_TipoEquipamientoConfiguration());
            modelBuilder.ApplyConfiguration(new EV_SeguroConfiguration());
            modelBuilder.ApplyConfiguration(new EV_TipoObraConfiguration());
            modelBuilder.ApplyConfiguration(new EV_RepTecnicoConfiguration());
            modelBuilder.ApplyConfiguration(new EV_AdministracionConfiguration());
            modelBuilder.ApplyConfiguration(new EV_ConservadoraConfiguration());
            modelBuilder.ApplyConfiguration(new EV_MaquinaConfiguration());
            modelBuilder.ApplyConfiguration(new EV_ObraConfiguration());
            modelBuilder.ApplyConfiguration(new EV_PersonaConfiguration());
            modelBuilder.ApplyConfiguration(new EV_CalleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}