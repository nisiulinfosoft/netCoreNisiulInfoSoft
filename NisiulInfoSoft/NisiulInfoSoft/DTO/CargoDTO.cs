using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.DTO
{
    public class CargoDTO
    {
        public int IdCar { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public bool? Estado { get; set; }

        public virtual List<PersonalDTO> Personal { get; set; }
    }
}
