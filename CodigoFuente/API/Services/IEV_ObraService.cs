using API.DataSchema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IEV_ObraService : ICRUDService<EV_Obra>
    {
        Task<IEnumerable<EV_Obra>> GetObrasCalleDesdeHasta(int idCalle, int desde, int hasta);
    }
}
