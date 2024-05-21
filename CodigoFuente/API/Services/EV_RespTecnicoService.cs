using rsAPIElevador.DataSchema;
using rsAPIElevador.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rsAPIElevador.Services
{
    public class EV_RespTecnicoService : BaseCRUDService<EV_RepTecnico>, IEV_RespTecnicoService
    {
        IEV_RespTecnicoRepository _repository;  
        public EV_RespTecnicoService(IEV_RespTecnicoRepository genericRepo) : base(genericRepo)
        {
            _repository = genericRepo;  
        }

        public Task<int> CantMaquinasDisponibles(int idRespTec)
        {
            return _repository.CantMaquinasDisponibles(idRespTec);
        }

        public Task<int> CantMaquinasxTecnico(int idRespTecnico)
        {
            return _repository.CantMaquinasxTecnico(idRespTecnico);
        }
    }
}
