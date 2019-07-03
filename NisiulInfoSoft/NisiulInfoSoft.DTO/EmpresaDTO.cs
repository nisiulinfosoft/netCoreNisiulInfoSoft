using System;
using System.Collections.Generic;
using System.Text;

namespace NisiulInfoSoft.DTO
{
    public class EmpresaDTO
    {
        public int IdEmp { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string PaginaWeb { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Distrito { get; set; }
        public string Observacion { get; set; }
        public bool? Estado { get; set; }

        public virtual List<PersonalDTO> Personal { get; set; }
    }
}
