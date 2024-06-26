﻿using API.DataSchema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IEV_ConservadoraService : ICRUDService<EV_Conservadora>
    {
        Task DeleteRespTec(int idCons, int idRespTec);
        Task AddRespTec(int idCons, int idRespTec);
        Task<IEnumerable<EV_RepTecnico>> GetRepTec(int idCons);
    }
}
