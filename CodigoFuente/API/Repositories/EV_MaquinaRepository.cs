using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using rsAPIElevador.DataSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace rsAPIElevador.Repositories
{
    public class EV_MaquinaRepository : BaseRepository<EV_Maquina>, IEV_MaquinaRepository
    {
        public EV_MaquinaRepository(DataContext context) : base(context)
        {
        }

        public  async Task<IEnumerable<EV_Maquina>> GetMaquinasxConsSinRespTec(int id)
        {
            IEnumerable<EV_Maquina> maquinas = await _context.EV_Maquina.IgnoreAutoIncludes()
                .Include(z => z.EV_TipoEquipamiento)
                //.Include(y => y.EV_Obra).ThenInclude(p => p.EV_Maquina == null).IgnoreAutoIncludes() //esto era un intento de hook para evitar autoinclude EV_Maquina pero no funciona 
                .Include(y => y.EV_Obra).IgnoreAutoIncludes()
                .Where(x => x.IdConservadora == id && x.IdRepTecnico == null).IgnoreAutoIncludes().AsNoTracking().ToListAsync();
            //Esto es un hook debido a que la instruccion .Include(y => y.EV_Obra).IgnoreAutoIncludes() no da resultados, seguramente sea un bug de EF.

            /*
            foreach (EV_Maquina maquina in maquinas)
            {
                maquina.EV_Obra.EV_Maquina = null;
            }
            return maquinas;
            */
            
            //Esto es un hook igual al de arriba debido a que la instruccion .Include(y => y.EV_Obra).IgnoreAutoIncludes() no da resultados, seguramente sea un bug de EF.
            return maquinas.Select(maquina =>
            {
                maquina.EV_Obra.EV_Maquina = null;
                return maquina;
            });
        }

        public async Task<EV_Maquina> FindNoInclude(int idMaquina)
        {
            EV_Maquina  maquina = await _context.EV_Maquina.Where(x => x.IdMaquina == idMaquina).IgnoreAutoIncludes().FirstOrDefaultAsync();    
            return maquina;
        }


    }
}
