using rsAPIElevador.DataSchema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rsAPIElevador.Services
{
    public interface IEV_RespTecnicoService : ICRUDService<EV_RepTecnico>
    {
        Task<int> CantMaquinasDisponibles(int idRespTec);

        Task<int> CantMaquinasxTecnico(int idRespTecnico);
        
    }
}
