using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using API.DataSchema;
using API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System;
using SQLitePCL;

namespace API.Repositories
{
    public class EV_RespTenicoRepository : BaseRepository<EV_RepTecnico>, IEV_RespTecnicoRepository
    {

        private readonly DataContext _context;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        public EV_RespTenicoRepository(DataContext context,Microsoft.Extensions.Configuration.IConfiguration configuration) : base(context)
        {
            _context = context; 
            _configuration = configuration;
        }

        public async Task<int> CantMaquinasDisponibles(int idRespTec)
        {
            int IdRespTecnico = idRespTec;
            int cantMaquinasxTecnico = await this.CantMaquinasxTecnico(idRespTec);
            string cantMaquinasxRespTec = _configuration["cantMaquinasxRespTec"].ToString();//traer esto del configuration
            int maquinasDisponibles = int.Parse(cantMaquinasxRespTec) - Convert.ToInt32(cantMaquinasxTecnico);
            return maquinasDisponibles;
        }


        public async Task<int> CantMaquinasxTecnico(int idRespTecnico)
        {
            return await Task.FromResult(_context.EV_Maquina.Where(x => x.IdRepTecnico == idRespTecnico).AsNoTracking().Count());
        }


        public override async Task<EV_RepTecnico> Find(int id)
        {

            EV_RepTecnico tecnico = await _context.EV_RepTecnico
                            .AsNoTracking()
                            .Include(a => a.EV_Maquina)
                                .ThenInclude(b => b.EV_TipoEquipamiento)  // Incluir relación con EV_TipoEquipamiento
                            .Include(a => a.EV_Maquina)  // Incluir relación con EV_Obra
                                .ThenInclude(y => y.EV_Obra)
                                .ThenInclude(z => z.EV_Calle)
                            .IgnoreAutoIncludes()
                            .IgnoreAutoIncludes()
                            .IgnoreAutoIncludes()
                            .Include(d => d.EV_Calle)
                            .IgnoreAutoIncludes()
                            .FirstAsync(e => e.IdRepTecnico == id);
            return tecnico;
        }
    }
}