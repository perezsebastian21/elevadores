using  rsAPIElevador.DataSchema;
using  rsAPIElevador.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rsAPIElevador.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("[controller]")]
    public class SeguroController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICRUDService<EV_Seguro> _serviceGenerico;

        public SeguroController(DataContext context, ILogger<EV_Seguro> logger, ICRUDService<EV_Seguro> serviceGenerico)
        {
            _context = context;
            _serviceGenerico = serviceGenerico;
        }
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<EV_Seguro>>> Get() //TODO: el método no contiene await, ya que devuelve un IEnumerable, que no puede ser awaiteado, ver como se puede implementar
        {
            
           IEnumerable<EV_Seguro> seguros = new List<EV_Seguro>();
           seguros = _serviceGenerico.GetAll();

           if (seguros != null)
               return Ok(seguros);
           else
               return NotFound();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<EV_Seguro>> Get(int Id)
        {
            EV_Seguro seguro = new EV_Seguro();
            seguro = await _serviceGenerico.GetByID(Id);
            if (seguro != null)
            {
                return Ok(seguro);
            }else
                return NotFound(); 
        }
        
        [HttpGet("GetByName")]
        public async Task<ActionResult<List<EV_Seguro>>> Get(string Name)
        {
            List<EV_Seguro> seguro = new List<EV_Seguro>();
            seguro = (List<EV_Seguro>)await _serviceGenerico.GetByParam(u => u.Nombre == Name);
            if (seguro != null && seguro.Count()>0)
            {
                return Ok(seguro);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EV_Seguro seguro)
        {
            await _serviceGenerico.Add(seguro);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            await _serviceGenerico.Delete(Id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EV_Seguro seguro)
        {
            await _serviceGenerico.Update(seguro);
            return Ok();
        }

    }
}
