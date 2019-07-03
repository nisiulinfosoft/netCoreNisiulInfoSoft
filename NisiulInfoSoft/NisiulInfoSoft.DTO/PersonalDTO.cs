using System;
using System.Collections.Generic;
using System.Text;

namespace NisiulInfoSoft.DTO
{
    public class PersonalDTO
    {
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

        public virtual AreaDTO Area { get; set; }
        public virtual CargoDTO Cargo { get; set; }
        public virtual EmpresaDTO Empresa { get; set; }

        public virtual List<UsuarioDTO> Usuario { get; set; }
    }
}
