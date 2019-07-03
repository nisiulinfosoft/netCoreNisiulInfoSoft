using System;
using System.Collections.Generic;

namespace NisiulInfosoft.EF.CodeFirst.Entities
{
    public partial class NisArea
    {
        public NisArea()
        {
            NisPersonal = new HashSet<NisPersonal>();
        }

        public int IdAre { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<NisPersonal> NisPersonal { get; set; }
    }
}