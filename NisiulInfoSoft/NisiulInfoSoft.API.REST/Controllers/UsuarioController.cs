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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var usuarios = _usuarioService.Listar();

            return Ok(usuarios);
        }

        [HttpGet]
        public IActionResult ListarQueryable()
        {
            var usuarios = _usuarioService.ListarQueryable();

            return Ok(usuarios);
        }

        [HttpGet]
        public IActionResult Recuperar(int id)
        {
            var usuario = _usuarioService.ObtenerPorId(id);

            if (usuario == null)
            {
                return BadRequest("El codigo que enviaste no existe");
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] UsuarioDTO usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (usuario.IdTip == 0)
            {
                return BadRequest("Debe enviar id tipo de usuario");
            }

            if (usuario.IdPer == 0)
            {
                return BadRequest("Debe enviar id de personal");
            }

            if (string.IsNullOrEmpty(usuario.Usuario))
            {
                return BadRequest("Debe enviar usuario");
            }

            if (string.IsNullOrEmpty(usuario.Contrasenia))
            {
                return BadRequest("Debe enviar contraseña");
            }

            var usuarioInsertar = _usuarioService.Insertar(usuario);

            return Ok(usuarioInsertar);

        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] UsuarioDTO usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (usuario.IdTip == 0)
            {
                return BadRequest("Debe enviar id tipo de usuario");
            }

            if (usuario.IdPer == 0)
            {
                return BadRequest("Debe enviar id de personal");
            }

            if (string.IsNullOrEmpty(usuario.Usuario))
            {
                return BadRequest("Debe enviar usuario");
            }

            if (string.IsNullOrEmpty(usuario.Contrasenia))
            {
                return BadRequest("Debe enviar contraseña");
            }

            var usuarioActualizar = _usuarioService.Actualizar(usuario);

            if (usuarioActualizar == null)
            {
                return BadRequest("Usuario no actualizado");
            }

            return Ok(usuarioActualizar);

        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var usuarioEliminar = _usuarioService.Eliminar(id);

            if (usuarioEliminar == false)
            {
                return BadRequest("Usuario no eliminado");
            }

            return Ok("Usuario eliminado");
        }
    }
}
