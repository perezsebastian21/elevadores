using System.Collections.Generic;

namespace API.DataSchema.DTO
{
    public class RespTecXMaquinasDTO
    {
        public int IdRepTecnico { get; set; }
        public List<int> idMaquina { get; set; }
    }
}
