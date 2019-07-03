using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.ClientWeb.Models
{
    public class EstadoModel
    {
        public List<SelectListItem> listItemsEstados { get; }

        public EstadoModel()
        {
            var estados = new List<SelectListItem>
            {
                new SelectListItem() {Text = "Activo", Value="True"},
                new SelectListItem() {Text = "Inactivo", Value="False"}
            };

            listItemsEstados = estados;
        }
    }
}
