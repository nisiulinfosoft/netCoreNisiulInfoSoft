using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.API.REST.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CargoController : ControllerBase
    {
        private ICargoService _cargoService;
        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var cargos = _cargoService.Listar();

            return Ok(cargos);
        }

        [HttpGet]
        public IActionResult Recuperar(int id)
        {
            var cargo = _cargoService.ObtenerPorId(id);

            if (cargo == null)
            {
                return BadRequest("El codigo que enviaste no existe");
            }

            return Ok(cargo);
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] CargoDTO cargo)
        {
            if (cargo == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (string.IsNullOrEmpty(cargo.Descripcion))
            {
                return BadRequest("Debe enviar descripción");
            }

            var cargoInsertar = _cargoService.Insertar(cargo);

            return Ok(cargoInsertar);

        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] CargoDTO cargo)
        {
            if (cargo == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (cargo.IdCar == 0)
            {
                return BadRequest("Debe enviar id");
            }

            if (string.IsNullOrEmpty(cargo.Descripcion))
            {
                return BadRequest("Debe enviar descripción");
            }

            var cargoActualizar = _cargoService.Actualizar(cargo);

            if (cargoActualizar == null)
            {
                return BadRequest("Cargo no actualizado");
            }

            return Ok(cargoActualizar);

        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var cargoEliminar = _cargoService.Eliminar(id);

            if (cargoEliminar == false)
            {
                return BadRequest("Cargo no eliminado");
            }

            return Ok("Cargo eliminado");
        }
    }
}
