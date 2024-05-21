using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using rsAPIElevador.DataSchema;

namespace rsAPIElevador.Repositories
{
    public interface IEV_ObraRepository : IRepository<EV_Obra> 
    {
        Task<IEnumerable<EV_Obra>> GetObrasCalleDesdeHasta(int idCalle, int desde, int hasta);
    }
}
