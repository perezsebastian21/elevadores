using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.DataSchema;

namespace API.Repositories
{
    public interface IEV_MaquinaRepository : IRepository<EV_Maquina> 
    {
        Task<IEnumerable<EV_Maquina>> GetMaquinasxConsSinRespTec(int id);

        Task<EV_Maquina> FindNoInclude(int idMaquina);
     
    }
}
