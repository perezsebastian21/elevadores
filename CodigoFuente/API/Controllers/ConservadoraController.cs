using  rsAPIElevador.DataSchema;
using  rsAPIElevador.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace rsAPIElevador.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("[controller]")]
    public class ConservadoraController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICRUDService<EV_Conservadora> _serviceGenerico;
        private readonly IEV_ConservadoraService _service;

        public ConservadoraController(DataContext context, ILogger<EV_Conservadora> logger, ICRUDService<EV_Conservadora> serviceGenerico, IEV_ConservadoraService service)
        {
            _context = context;
            _serviceGenerico = serviceGenerico;
            _service = service;
        }
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<EV_Conservadora>>> Get() //TODO: el método no contiene await, ya que devuelve un IEnumerable, que no puede ser awaiteado, ver como se puede implementar
        {
            return Ok(_serviceGenerico.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<EV_Conservadora>> Get(int Id)
        {
            return Ok(await _serviceGenerico.GetByID(Id));
            //return Ok(await _service.GetByID(Id));
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<EV_Conservadora>> Get(string Name)
        {
            return Ok(await _serviceGenerico.GetByParam(u => u.Nombre == Name));
        }
        
        [HttpGet("GetRespTec")]
        public async Task<ActionResult<IEnumerable<EV_RepTecnico>>> GetRespTec(int idCons) 
        {
            //return Ok();
            return Ok(await _service.GetRepTec(idCons));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EV_Conservadora conservadora)
        {
            await _serviceGenerico.Add(conservadora);
            return Ok(conservadora);
        }

        [HttpDelete("DeleteRespTec")]
        public async Task<IActionResult> DeleteRespTec(int idCons, int idRepTec)
        {
            await _service.DeleteRespTec(idCons, idRepTec);
            return Ok();
        }

        [HttpPost("AddRespTec")]
        public async Task<IActionResult> AddRespTec(int idCons, int idRepTecnico)
        {
            await _service.AddRespTec(idCons, idRepTecnico);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _serviceGenerico.Delete(Id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<EV_Conservadora>> Update([FromBody] EV_Conservadora conservadora)
        {
            await _serviceGenerico.Update(conservadora);
            return Ok(conservadora);
        }

    }
}
