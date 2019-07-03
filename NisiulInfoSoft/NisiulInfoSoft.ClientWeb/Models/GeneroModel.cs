using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.ClientWeb.Models
{
    public class GeneroModel
    {
        public List<SelectListItem> listItemsGeneros { get; }

        public GeneroModel()
        {
            var generos = new List<SelectListItem>
            {
                new SelectListItem() {Text = "Masculino", Value="M"},
                new SelectListItem() {Text = "Femenino", Value="F"}
            };

            listItemsGeneros = generos;
        }
    }
}
