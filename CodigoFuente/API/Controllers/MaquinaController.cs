using  rsAPIElevador.DataSchema;
using  rsAPIElevador.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rsAPIElevador.Repositories;
using rsAPIElevador.DataSchema.DTO;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace rsAPIElevador.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("[controller]")]
    public class MaquinaController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICRUDService<EV_Maquina> _serviceGenerico;

        private readonly IEV_MaquinaService _service;
        public MaquinaController(DataContext context, ILogger<EV_Maquina> logger, IEV_MaquinaService serviceGenerico)
        {
            _context = context;
            _serviceGenerico = serviceGenerico;
            _service = serviceGenerico;

        }
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<EV_Maquina>>> Get() //TODO: el método no contiene await, ya que devuelve un IEnumerable, que no puede ser awaiteado, ver como se puede implementar
        {
            return Ok(_serviceGenerico.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<EV_Maquina>> Get(int Id)
        {
            return Ok(await _serviceGenerico.GetByID(Id));
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<EV_Maquina>> Get(string Name)
        {
            return Ok(await _serviceGenerico.GetByParam(u => u.NroSerie == Name));
        }

        [HttpGet("GetXConsSinRespTec")]
        public async Task<ActionResult<EV_Maquina>> GetXConsSinRespTec(int idCons)
        {
            return Ok(await _service.GetMaquinasxConsSinRespTec(idCons));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EV_Maquina maquina)
        {
            await _serviceGenerico.Add(maquina);
            return Ok(maquina);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _serviceGenerico.Delete(Id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<EV_Maquina>> Update([FromBody] EV_Maquina maquina)
        {
            await _serviceGenerico.Update(maquina);
            return Ok(maquina);
        }

        /*
        [HttpPut]
        public async Task<ActionResult<EV_Maquina>> Update([FromBody] IEnumerable<EV_Maquina> maquinas)
        {
            await _service.addRespTecnicoMaquinasSinAsignar(maquinas);
            return Ok();
        }*/

        [HttpPut("autoasignarRespTecxMaq")]
        public async Task<ActionResult<EV_Maquina>> Update([FromBody] RespTecXMaquinasDTO maquinas)
        {
            int cantAsignadas = await _service.addRespTecnicoMaquinasSinAsignar(maquinas);
            int totalMaquinas = maquinas.idMaquina.Count();
            if (cantAsignadas <= totalMaquinas) {
                var partialContentResult = new ObjectResult(string.Format("Se alcanzó el límite de máquinas para el técnico seleccionado. Se asignaron {0} de {1} máquinas. Restan asignar {2}", cantAsignadas, totalMaquinas, totalMaquinas - cantAsignadas))
                {
                    StatusCode = 206
                };
                partialContentResult.ContentTypes.Add("application/json");
                return partialContentResult;
            }else{
                return Ok("Se asginaron todas las máquinas con éxito");
            }

        }
    }
}
