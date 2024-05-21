using System.Collections.Generic;

namespace rsAPIElevador.DataSchema.DTO
{
    public class RespTecXMaquinasDTO
    {
        public int IdRepTecnico { get; set; }
        public List<int> idMaquina { get; set; }
    }
}
