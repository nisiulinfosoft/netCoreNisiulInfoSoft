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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioService _tipoUsuarioService;
        public TipoUsuarioController(ITipoUsuarioService tipoUsuarioService)
        {
            _tipoUsuarioService = tipoUsuarioService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var tipoUsuarios = _tipoUsuarioService.Listar();

            return Ok(tipoUsuarios);
        }

        [HttpGet]
        public IActionResult ListarQueryable()
        {
            var tipoUsuarios = _tipoUsuarioService.ListarQueryable();

            return Ok(tipoUsuarios);
        }

        [HttpGet]
        public IActionResult Recuperar(int id)
        {
            var tipoUsuario = _tipoUsuarioService.ObtenerPorId(id);

            if (tipoUsuario == null)
            {
                return BadRequest("El codigo que enviaste no existe");
            }

            return Ok(tipoUsuario);
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] TipoUsuarioDTO tipoUsuario)
        {
            if (tipoUsuario == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (string.IsNullOrEmpty(tipoUsuario.Descripcion))
            {
                return BadRequest("Debe enviar descripción");
            }

            var tipoUsuarioInsertar = _tipoUsuarioService.Insertar(tipoUsuario);

            return Ok(tipoUsuarioInsertar);

        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] TipoUsuarioDTO tipoUsuario)
        {
            if (tipoUsuario == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (tipoUsuario.IdTip == 0)
            {
                return BadRequest("Debe enviar id");
            }

            if (string.IsNullOrEmpty(tipoUsuario.Descripcion))
            {
                return BadRequest("Debe enviar descripción");
            }

            var tipoUsuarioActualizar = _tipoUsuarioService.Actualizar(tipoUsuario);

            if (tipoUsuarioActualizar == null)
            {
                return BadRequest("Tipo de usuario no actualizado");
            }

            return Ok(tipoUsuarioActualizar);

        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var tipoUsuarioEliminar = _tipoUsuarioService.Eliminar(id);

            if (tipoUsuarioEliminar == false)
            {
                return BadRequest("Tipo de usuario no eliminado");
            }

            return Ok("Tipo de usuario eliminado");
        }
    }
}
