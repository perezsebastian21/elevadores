using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using rsAPIElevador.DataSchema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rsAPIElevador.Repositories
{
    public class EV_ObraRepository : BaseRepository<EV_Obra>, IEV_ObraRepository
    {
        private readonly DataContext _context;
        public EV_ObraRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        
        public override IQueryable<EV_Obra> AllAsNoTracking()
        {
            IQueryable<EV_Obra> obras = _context.EV_Obra
                .Include(x => x.EV_Administracion)
                .Include(x => x.EV_TipoObra)
                .Include(x => x.EV_Calle)
                .IgnoreAutoIncludes()
                .AsNoTracking();
            return obras;
        }

        public async Task<IEnumerable<EV_Obra>> GetObrasCalleDesdeHasta(int idCalle, int desde, int hasta)
        {
            return await _context.EV_Obra
                            .Include(x => x.EV_Administracion).IgnoreAutoIncludes()
                            .Include(x=> x.EV_Calle).IgnoreAutoIncludes()
                            .Include(x=> x.EV_TipoObra).IgnoreAutoIncludes()
                            .Where(x => x.IdCalle == idCalle && (x.Altura >= desde && x.Altura <= hasta)).AsNoTracking().ToListAsync();
        }
    }
}
