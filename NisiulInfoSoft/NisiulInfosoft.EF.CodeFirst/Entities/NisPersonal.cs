using System;
using System.Collections.Generic;

namespace NisiulInfosoft.EF.CodeFirst.Entities
{
    public partial class NisPersonal
    {
        public NisPersonal()
        {
            NisUsuario = new HashSet<NisUsuario>();
        }

        public int IdPer { get; set; }
        public int IdEmp { get; set; }
        public int IdAre { get; set; }
        public int IdCar { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaContacto { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Observacion { get; set; }
        public bool? Estado { get; set; }

        public virtual NisArea IdAreNavigation { get; set; }
        public virtual NisCargo IdCarNavigation { get; set; }
        public virtual NisEmpresa IdEmpNavigation { get; set; }
        public virtual ICollection<NisUsuario> NisUsuario { get; set; }
    }
}