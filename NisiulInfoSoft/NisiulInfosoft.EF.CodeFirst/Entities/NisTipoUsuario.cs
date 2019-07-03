using System;
using System.Collections.Generic;

namespace NisiulInfosoft.EF.CodeFirst.Entities
{
    public partial class NisTipoUsuario
    {
        public NisTipoUsuario()
        {
            NisUsuario = new HashSet<NisUsuario>();
        }

        public int IdTip { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<NisUsuario> NisUsuario { get; set; }
    }
}