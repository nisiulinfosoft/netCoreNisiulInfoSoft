using System;
using System.Collections.Generic;

namespace NisiulInfosoft.EF.CodeFirst.Entities
{
    public partial class NisCargo
    {
        public NisCargo()
        {
            NisPersonal = new HashSet<NisPersonal>();
        }

        public int IdCar { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<NisPersonal> NisPersonal { get; set; }
    }
}