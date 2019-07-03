using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NisiulInfoSoft.ClientWeb.Filters;
using NisiulInfoSoft.ClientWeb.Models;
using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Services;

namespace NisiulInfoSoft.ClientWeb.Controllers
{
    [AutenticaFilter]
    public class CargoController : Controller
    {
        private ICargoService _cargoService;
        private EstadoModel estado;
        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
            estado = new EstadoModel();
        }

        public IActionResult Index()
        {
            return View(_cargoService.Listar());
        }

        [HttpGet]
        public IActionResult Editar(int id = 0)
        {
            CargoDTO cargo;

            if (id == 0) //nuevo
            {
                cargo = new CargoDTO();
            }
            else //editar
            {
                cargo = _cargoService.ObtenerPorId(id);
            }

            ViewBag.listItemsEstados = estado.listItemsEstados;

            return View(cargo);
        }

        [HttpPost]
        public IActionResult Grabar(CargoDTO cargo)
        {
            if (cargo.IdCar == 0)
            {
                _cargoService.Insertar(cargo);
            }
            else
            {
                _cargoService.Actualizar(cargo);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id = 0)
        {
            _cargoService.Eliminar(id);

            return RedirectToAction("Index");
        }
    }
}