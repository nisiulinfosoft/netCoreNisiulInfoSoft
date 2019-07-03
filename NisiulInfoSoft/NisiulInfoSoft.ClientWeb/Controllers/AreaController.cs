using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NisiulInfoSoft.ClientWeb.Filters;
using NisiulInfoSoft.ClientWeb.Models;
using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NisiulInfoSoft.ClientWeb.Controllers
{
    [AutenticaFilter]
    public class AreaController : Controller
    {
        private IAreaService _areaService;
        private EstadoModel estado;
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
            estado = new EstadoModel();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_areaService.Listar());
        }

        [HttpGet]
        public IActionResult Editar(int id = 0)
        {
            AreaDTO area;

            if (id == 0) //nuevo
            {
                area = new AreaDTO();
            }
            else //editar
            {
                area = _areaService.ObtenerPorId(id);
            }

            ViewBag.listItemsEstados = estado.listItemsEstados;

            return View(area);
        }

        [HttpPost]
        public IActionResult Grabar(AreaDTO area)
        {
            if (area.IdAre == 0)
            {
                _areaService.Insertar(area);
            }
            else
            {
                _areaService.Actualizar(area);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id = 0)
        {
            _areaService.Eliminar(id);

            return RedirectToAction("Index");
        }
    }
}
