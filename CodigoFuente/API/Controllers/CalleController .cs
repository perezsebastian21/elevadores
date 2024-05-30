using  API.DataSchema;
using  API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    //[Authorize(Roles = "Admin")]
    [AllowAnonymous]
    [Route("[controller]")]
    public class CalleController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICRUDService<EV_Calle> _serviceGenerico;

        public CalleController(DataContext context, ILogger<EV_Calle> logger, ICRUDService<EV_Calle> serviceGenerico)
        {
            _context = context;
            _serviceGenerico = serviceGenerico;
        }
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<EV_Calle>>> Get() //TODO: el método no contiene await, ya que devuelve un IEnumerable, que no puede ser awaiteado, ver como se puede implementar
        {
            return Ok(_serviceGenerico.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<EV_Calle>> Get(int Id)
        {
            return Ok(await _serviceGenerico.GetByID(Id));
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<EV_Calle>> Get(string Name)
        {
            return Ok(await _serviceGenerico.GetByParam(u => u.Nombre == Name));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EV_Calle calle)
        {
            await _serviceGenerico.Add(calle);
            return Ok(calle);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _serviceGenerico.Delete(Id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<EV_TipoObra>> Update([FromBody] EV_Calle calle)
        {
            await _serviceGenerico.Update(calle);
            return Ok(calle);
        }

    }
}
