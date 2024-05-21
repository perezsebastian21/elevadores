using rsAPIElevador.DataSchema;
using rsAPIElevador.DataSchema.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rsAPIElevador.Services
{
    public interface IEV_MaquinaService : ICRUDService<EV_Maquina>
    {
        Task<IEnumerable<EV_Maquina>> GetMaquinasxConsSinRespTec(int id);

        Task<int> addRespTecnicoMaquinasSinAsignar(RespTecXMaquinasDTO maquinas);

        //Task<int> CantMaquinasxTecnico(int idRespTecnico);
    }
}
