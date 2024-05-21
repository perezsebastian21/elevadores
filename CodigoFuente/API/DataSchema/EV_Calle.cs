using System.Collections.Generic;

namespace rsAPIElevador.DataSchema
{
    public class EV_Calle
    {
        public int IdCalle { get; set; }   
        public string Nombre { get; set; }
        public virtual ICollection<EV_Obra>? EV_Obra { get; set; }

        public virtual ICollection<EV_Conservadora>? EV_Conservadora { get; set; }

        public virtual ICollection<EV_Administracion>? EV_Administracion { get; set; }

        public virtual ICollection<EV_Seguro>? EV_Seguro { get; set; }

        public virtual ICollection<EV_RepTecnico>? EV_RepTecnico { get; set; }
    }
}
