using Microsoft.AspNetCore.Mvc;
using NisiulInfoSoft.API.REST.Util;
using NisiulInfoSoft.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.API.REST.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUsuarioService _usuarioService;
        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Generar(string login, string clave)
        {
            var usuario = _usuarioService.IniciarSesion(login, clave);

            if (usuario == null)
            {
                return BadRequest("Credenciales invalidas");
            }

            string token = Token.Generar(login, 10);

            return Ok(new { token });
        }
    }
}
