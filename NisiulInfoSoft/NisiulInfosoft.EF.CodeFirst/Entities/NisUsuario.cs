using System;
using System.Collections.Generic;

namespace NisiulInfosoft.EF.CodeFirst.Entities
{
    public partial class NisUsuario
    {
        public int IdUsu { get; set; }
        public int IdTip { get; set; }
        public int IdPer { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public bool? Estado { get; set; }

        public virtual NisPersonal IdPerNavigation { get; set; }
        public virtual NisTipoUsuario IdTipNavigation { get; set; }
    }
}