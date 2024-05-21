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
    public class EV_ObraService : BaseCRUDService<EV_Obra>, IEV_ObraService
    {
        IEV_ObraRepository _repository;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;       
        public EV_ObraService(IEV_ObraRepository genericRepo ,Microsoft.Extensions.Configuration.IConfiguration configuration) : base(genericRepo)
        {
            _repository = genericRepo;
            _configuration = configuration;     
        }

        public async Task<IEnumerable<EV_Obra>> GetObrasCalleDesdeHasta(int idCalle, int desde, int hasta)
        {
            return await _repository.GetObrasCalleDesdeHasta(idCalle, desde, hasta);
        }
    }
}
