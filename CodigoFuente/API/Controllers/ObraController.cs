using  API.DataSchema;
using  API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataSchema.DTO;

namespace API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("[controller]")]
    public class ObraController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IEV_ObraService _serviceGenerico;

        public ObraController(DataContext context, ILogger<EV_Obra> logger, IEV_ObraService serviceGenerico)
        {
            _context = context;
            _serviceGenerico = serviceGenerico;
        }
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<EV_Obra>>> Get() //TODO: el método no contiene await, ya que devuelve un IEnumerable, que no puede ser awaiteado, ver como se puede implementar
        {
            
            return Ok(_serviceGenerico.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<EV_Obra>> Get(int Id)
        {
            return Ok(await _serviceGenerico.GetByID(Id));
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<EV_Obra>> Get(string Name)
        {
            return Ok(await _serviceGenerico.GetByParam(u => u.Nombre == Name));
        }

        
        [HttpPost("GetByCalleDesdeHasta")]
        public async Task<ActionResult<EV_Obra>> GetByCalleDesdeHasta(ObraCalleDesdeHastaDTO calle)
        {
            return Ok(await _serviceGenerico.GetObrasCalleDesdeHasta(calle.IdCalle, calle.AlturaDesde, calle.AlturaHasta));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EV_Obra obra)
        {
            await _serviceGenerico.Add(obra);
            return Ok(obra);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _serviceGenerico.Delete(Id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<EV_Obra>> Update([FromBody] EV_Obra obra)
        {
            await _serviceGenerico.Update(obra);
            return Ok(obra);
        }

    }
}
