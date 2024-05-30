using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.DataSchema;

namespace API.Repositories
{
    public interface IEV_ConservadoraRepository : IRepository<EV_Conservadora> 
    {
        Task<IEnumerable<EV_RepTecnico>> GetRepTec(int idCons);
        Task AddRespTec(int idCons, int idRepTec);
        Task DeleteRespTec(int idCons, int idRepTec);
    }
}
