using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using API.DataSchema;
using API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System;
using SQLitePCL;

namespace API.Repositories
{
    public class EV_ConservadoraRepository : BaseRepository<EV_Conservadora>, IEV_ConservadoraRepository
    {

        private readonly DataContext _context;
        public EV_ConservadoraRepository(DataContext context) : base(context)
        {
            _context = context; 
        }

        public override async Task<EV_Conservadora> Find(int id)
        {
            EV_Conservadora conservadora = await _context.EV_Conservadora
                .Include(x => x.EV_Calle)
                .Include(x => x.EV_Seguro)
                .Include(x => x.EV_Maquina)
                    .ThenInclude(y => y.EV_TipoEquipamiento)
                .Include(x => x.EV_Maquina)
                    .ThenInclude(y => y.EV_Obra)
                .Include(x => x.EV_Maquina)
                    .ThenInclude(y => y.EV_Velocidades)
                .IgnoreAutoIncludes()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.IdConservadora == id);
            return conservadora;
        }

        public async Task<IEnumerable<EV_RepTecnico>> GetRepTec(int idCons)
        {
            IEnumerable<EV_RepTecnico> tecnicos = new List<EV_RepTecnico>();
            EV_Conservadora conservadora = new EV_Conservadora();
            conservadora = await _context.EV_Conservadora.FindAsync(idCons);
            return conservadora.EV_RepTecnico;
        }

        public Task AddRespTec(int idCons, int idRepTec)
        {
            //_context.EV_ConservadoraEV_RepTecnico.Remove(idCons, idRepTec);//algo asi seria creo que primero hay que hacer el find del objeto
            EV_Conservadora conservadora = new EV_Conservadora();
            conservadora = _context.EV_Conservadora.Find(idCons);
            EV_RepTecnico repTecnico = new EV_RepTecnico();
            repTecnico = _context.EV_RepTecnico.Find(idRepTec);
            conservadora.EV_RepTecnico.Add(repTecnico);
            //repTecnico.EV_Conservadora.Add(conservadora);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteRespTec(int idCons, int idRepTec)
        {
            //primero eliminar de la relacion conservadora x reptecnico

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                //accion 1

                //_context.EV_ConservadoraEV_RepTecnico.Remove(idCons, idRepTec);//algo asi seria creo que primero hay que hacer el find del objeto
                EV_Conservadora conservadora = new EV_Conservadora();
                conservadora = _context.EV_Conservadora.Find(idCons);
                EV_RepTecnico repTecnico = new EV_RepTecnico();
                repTecnico = _context.EV_RepTecnico.Find(idRepTec);
                if (conservadora != null && repTecnico != null)
                {
                    conservadora.EV_RepTecnico.Remove(repTecnico);
                    _context.SaveChanges();
                }
                
                if (conservadora != null && repTecnico != null)
                {
                    repTecnico.EV_Conservadora.Remove(conservadora);
                    _context.SaveChanges();
                }
                //accion 2                
                //obtener listado de maquinas para el id reptecnico y con un for eliminar
                _context.EV_Maquina.Where(m => m.IdConservadora == idCons)
                    .ToList()
                    .ForEach(m => m.EV_RepTecnico = null);
                _context.SaveChanges();
                //commit
                transaction.Commit();
            }
            catch (Exception)
            {
                // TODO: Handle failure
                throw new System.NotImplementedException();
            }
            //segundo realizar update en null sobre maquina para idreptecnico
            return Task.CompletedTask;
        }

        /*
        public async Task Add(EV_Conservadora conservadora)
        {

        }*/
    }
}