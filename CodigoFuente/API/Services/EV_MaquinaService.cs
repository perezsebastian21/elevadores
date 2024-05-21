using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using rsAPIElevador.DataSchema;
using rsAPIElevador.DataSchema.DTO;
using rsAPIElevador.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace rsAPIElevador.Services
{
    public class EV_MaquinaService : BaseCRUDService<EV_Maquina>, IEV_MaquinaService
    {
        IEV_MaquinaRepository _repository;
        IEV_RespTecnicoRepository _repositoryRespTecnico;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;       
        public EV_MaquinaService(IEV_MaquinaRepository genericRepo, IEV_RespTecnicoRepository repositoryRespTecnico,Microsoft.Extensions.Configuration.IConfiguration configuration) : base(genericRepo)
        {
            _repository = genericRepo;
            _repositoryRespTecnico = repositoryRespTecnico;
            _configuration = configuration;     
        }

        public async Task<IEnumerable<EV_Maquina>> GetMaquinasxConsSinRespTec(int id)
        {
            return await _repository.GetMaquinasxConsSinRespTec(id);
        }

        public async Task<int> addRespTecnicoMaquinasSinAsignar(RespTecXMaquinasDTO maquinas)
        {
            int IdRespTecnico = maquinas.IdRepTecnico;
            int maquinasDisponibles = await _repositoryRespTecnico.CantMaquinasDisponibles(IdRespTecnico);//
            int i = 0;
            for (i = 0; (i < maquinasDisponibles) && (i < maquinas.idMaquina.Count()); i++)
            {
                int idMaquina = maquinas.idMaquina[i];
                //EV_Maquina maquina = await _repository.Find(idMaquina);//este find hay que redefinirlo para este caso queno traiga las relaciones
                EV_Maquina maquina = await _repository.FindNoInclude(idMaquina);
                //o bien que se suspenda el tracking de la relacion
                //maquina.EV_TipoEquipamiento = null;//SACAR ESTE CABLE ES PARA QUE NO REVIENTE, HAY QUE HACER QUE EL FIN DE ARRIBA SEA SIN AUTOINLCUDE 
                //SINO REVIENTA PQ LO DEJA REFERENCIADO
                //hacer un override de ese find para que no traiga las relaciones 
                maquina.IdRepTecnico = IdRespTecnico;
                await _repository.Update(maquina);
            }
            return i;
        }

        public override async Task Add(EV_Maquina maquina)
        {
            //aca validar la limitacion del tecnico esta validacion va en el servicio no en el repositorio
            if (maquina.IdRepTecnico != null)
            {
                /*
                int cantMaquinasxTecnico = await _repositoryRespTecnico.CantMaquinasxTecnico(maquina.IdRepTecnico.Value);
                int totalMaquinas = int.Parse(_configuration["cantMaquinasxRespTec"].ToString());
                int maquinasDisponibles = totalMaquinas - cantMaquinasxTecnico;//int.Parse(cantMaquinasxTecnico);
                */
                int maquinasDisponibles = await _repositoryRespTecnico.CantMaquinasDisponibles(maquina.IdRepTecnico.Value);
                if (maquinasDisponibles > 0)
                {
                    await base.Add(maquina);
                }
                else
                {
                    throw new InvalidOperationException("Se ha alcanzado el límite de máquinas para este técnico.");
                }
            }
            else 
            {
                await base.Add(maquina);
            }
        }


        public override async Task Update(EV_Maquina maquina)
        {
            //aca validar la limitacion del tecnico esta validacion va en el servicio no en el repositorio
            if (maquina.IdRepTecnico != null) {
                /*
                int cantMaquinasxTecnico = await _repositoryRespTecnico.CantMaquinasxTecnico(maquina.IdRepTecnico.Value);
                int totalMaquinas = int.Parse(_configuration["cantMaquinasxRespTec"].ToString());
                int maquinasDisponibles = totalMaquinas - cantMaquinasxTecnico;//int.Parse(cantMaquinasxTecnico);
                */
                int maquinasDisponibles = await _repositoryRespTecnico.CantMaquinasDisponibles(maquina.IdRepTecnico.Value);
                if (maquinasDisponibles > 0)
                {
                    await base.Update(maquina);
                }
                else
                {
                    throw new InvalidOperationException("Se ha alcanzado el límite de máquinas para este técnico.");
                }
            }
            else
            {
                await base.Update(maquina);
            }
        }
    }
}
