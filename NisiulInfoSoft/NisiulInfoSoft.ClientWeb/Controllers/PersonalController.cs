using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NisiulInfoSoft.ClientWeb.Filters;
using NisiulInfoSoft.ClientWeb.Models;
using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Services;

namespace NisiulInfoSoft.ClientWeb.Controllers
{
    [AutenticaFilter]
    public class PersonalController : Controller
    {
        private IPersonalService _personalService;
        private IAreaService _areaService;
        private ICargoService _cargoService;
        private IEmpresaService _empresaService;
        private GeneroModel genero;
        private EstadoModel estado;

        public PersonalController(IPersonalService personalService, 
            IAreaService areaService, 
            ICargoService cargoService,
            IEmpresaService empresaService)
        {
            _personalService = personalService;
            _areaService = areaService;
            _cargoService = cargoService;
            _empresaService = empresaService;
            genero = new GeneroModel();
            estado = new EstadoModel();
        }

        public IActionResult Index()
        {
            return View(_personalService.Listar());
        }

        [HttpGet]
        public IActionResult Editar(int id = 0)
        {
            PersonalDTO personal;

            if (id == 0) //nuevo
            {
                personal = new PersonalDTO();
            }
            else //editar
            {
                personal = _personalService.ObtenerPorId(id);
            }

            var listItemsEmpresas = from e in _empresaService.Listar()
                                    select new SelectListItem
                                    {
                                        Text = e.RazonSocial,
                                        Value = e.IdEmp.ToString()
                                    };

            var listItemsAreas = from a in _areaService.Listar()
                                 select new SelectListItem
                                 {
                                     Text = a.Descripcion,
                                     Value = a.IdAre.ToString()
                                 };

            var listItemsCargos = from c in _cargoService.Listar()
                                  select new SelectListItem
                                  {
                                     Text = c.Descripcion,
                                     Value = c.IdCar.ToString()
                                  };

            ViewBag.areas = listItemsAreas;
            ViewBag.cargos = listItemsCargos;
            ViewBag.empresas = listItemsEmpresas;
            ViewBag.listItemsGeneros = genero.listItemsGeneros;
            ViewBag.listItemsEstados = estado.listItemsEstados;

            return View(personal);
        }

        [HttpGet]
        public IActionResult Detalle(int id = 0)
        {
            PersonalDTO personal;

            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            personal = _personalService.ObtenerPorId(id);

            if (personal == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.empresa = _empresaService.ObtenerPorId(personal.IdEmp).RazonSocial;
            ViewBag.area = _areaService.ObtenerPorId(personal.IdAre).Descripcion;
            ViewBag.cargo = _cargoService.ObtenerPorId(personal.IdCar).Descripcion;

            return View(personal);
        }

        [HttpPost]
        public IActionResult Grabar(PersonalDTO personal)
        {
            if (personal.IdAre == 0)
            {
                _personalService.Insertar(personal);
            }
            else
            {
                _personalService.Actualizar(personal);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id = 0)
        {
            _personalService.Eliminar(id);

            return RedirectToAction("Index");
        }
    }
}