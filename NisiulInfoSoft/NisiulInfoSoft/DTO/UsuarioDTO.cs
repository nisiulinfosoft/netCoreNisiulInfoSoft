using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.DTO
{
    public class UsuarioDTO
    {
        public int IdUsu { get; set; }
        public int IdTip { get; set; }
        public int IdPer { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public bool? Estado { get; set; }

        public virtual PersonalDTO Personal { get; set; }
        public virtual TipoUsuarioDTO TipoUsuario { get; set; }
    }
}
