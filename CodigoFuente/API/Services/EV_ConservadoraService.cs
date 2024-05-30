using API.DataSchema;
using API.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class EV_ConservadoraService : BaseCRUDService<EV_Conservadora>, IEV_ConservadoraService
    {
        IEV_ConservadoraRepository _repository;  
        public EV_ConservadoraService(IEV_ConservadoraRepository genericRepo) : base(genericRepo)
        {
            _repository = genericRepo;  
        }
        public Task<IEnumerable<EV_RepTecnico>> GetRepTec(int idCons)
        {
            return _repository.GetRepTec(idCons);
        }

        public Task AddRespTec(int idCons, int idRespTec)
        {
            return _repository.AddRespTec(idCons, idRespTec);
        }

        public Task DeleteRespTec(int idCons, int idRespTec)
        {
            return _repository.DeleteRespTec(idCons, idRespTec);
        }
    }
}
