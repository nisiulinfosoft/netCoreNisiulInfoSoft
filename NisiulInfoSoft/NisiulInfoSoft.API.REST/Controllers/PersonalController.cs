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
    public class PersonalController : ControllerBase
    {
        private IPersonalService _personalService;
        public PersonalController(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var personales = _personalService.Listar();

            return Ok(personales);
        }

        [HttpGet]
        public IActionResult ListarPorDNI(string dni)
        {
            var personales = _personalService.ListarPorDNI(dni);

            return Ok(personales);
        }

        [HttpGet]
        public IActionResult Recuperar(int id)
        {
            var personal = _personalService.ObtenerPorId(id);

            if (personal == null)
            {
                return BadRequest("El codigo que enviaste no existe");
            }

            return Ok(personal);
        }

        [HttpGet]
        public IActionResult RecuperarPorDNI(string dni)
        {
            var personal = _personalService.ObtenerPorDNI(dni);

            if (personal == null)
            {
                return BadRequest("El DNI que enviaste no existe");
            }

            return Ok(personal);
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] PersonalDTO personal)
        {
            if (personal == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (string.IsNullOrEmpty(personal.Dni))
            {
                return BadRequest("Debe enviar DNI");
            }

            if (string.IsNullOrEmpty(personal.Nombre))
            {
                return BadRequest("Debe enviar nombre");
            }

            if (string.IsNullOrEmpty(personal.ApellidoPaterno))
            {
                return BadRequest("Debe enviar apellido paterno");
            }

            if (string.IsNullOrEmpty(personal.ApellidoMaterno))
            {
                return BadRequest("Debe enviar apellido materno");
            }

            var personalInsertar = _personalService.Insertar(personal);

            return Ok(personalInsertar);

        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] PersonalDTO personal)
        {
            if (personal == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (personal.IdPer == 0)
            {
                return BadRequest("Debe enviar id");
            }

            if (personal.IdEmp == 0)
            {
                return BadRequest("Debe enviar id de empresa");
            }

            if (personal.IdAre == 0)
            {
                return BadRequest("Debe enviar id de área");
            }

            if (personal.IdCar == 0)
            {
                return BadRequest("Debe enviar id de cargo");
            }

            if (string.IsNullOrEmpty(personal.Dni))
            {
                return BadRequest("Debe enviar DNI");
            }

            if (string.IsNullOrEmpty(personal.Nombre))
            {
                return BadRequest("Debe enviar nombre");
            }

            if (string.IsNullOrEmpty(personal.ApellidoPaterno))
            {
                return BadRequest("Debe enviar apellido paterno");
            }

            if (string.IsNullOrEmpty(personal.ApellidoMaterno))
            {
                return BadRequest("Debe enviar apellido materno");
            }

            var personalActualizar = _personalService.Actualizar(personal);

            if (personalActualizar == null)
            {
                return BadRequest("Personal no actualizado");
            }

            return Ok(personalActualizar);

        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var personalEliminar = _personalService.Eliminar(id);

            if (personalEliminar == false)
            {
                return BadRequest("Personal no eliminado");
            }

            return Ok("Personal eliminado");
        }
    }
}
