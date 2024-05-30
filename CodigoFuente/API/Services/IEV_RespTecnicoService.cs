using API.DataSchema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IEV_RespTecnicoService : ICRUDService<EV_RepTecnico>
    {
        Task<int> CantMaquinasDisponibles(int idRespTec);

        Task<int> CantMaquinasxTecnico(int idRespTecnico);
        
    }
}
