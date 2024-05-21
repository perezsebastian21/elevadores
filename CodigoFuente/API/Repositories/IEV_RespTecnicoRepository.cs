﻿using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using rsAPIElevador.DataSchema;

namespace rsAPIElevador.Repositories
{
    public interface IEV_RespTecnicoRepository : IRepository<EV_RepTecnico> 
    {
        Task <int> CantMaquinasDisponibles(int idRespTec);

        Task<int> CantMaquinasxTecnico(int idRespTecnico);
    }
}
