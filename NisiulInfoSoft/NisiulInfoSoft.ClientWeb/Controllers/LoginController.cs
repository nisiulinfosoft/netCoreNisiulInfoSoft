using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Services;

namespace NisiulInfoSoft.ClientWeb.Controllers
{
    public class LoginController : Controller
    {
        private IUsuarioService _usuarioService;
        //private readonly SignInManager<IdentityUser> _manager;

        //, SignInManager<IdentityUser> manager
        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            //_manager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UsuarioDTO usuario = new UsuarioDTO();

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Index(string Usuario, string Contrasenia)
        {
            UsuarioDTO usu = _usuarioService.IniciarSesion(Usuario, Contrasenia);

            if (usu == null)
            {
                ModelState.AddModelError("*", "Credenciales invalidas");
                return View(usu);
            }
            else
            {
                //grabarlo en sesion 
                HttpContext.Session.SetString("login", usu.Usuario);
                usu.Contrasenia = "";
                string usuariotexto = JsonConvert.SerializeObject(usu);
                HttpContext.Session.SetString("user", usuariotexto);
                return RedirectToAction("Index", "Home");
            }

        }

        public IActionResult CerrarSesion()
        {
            //limpiar la sesion

            //Limpiar cookies
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }

        //public IActionResult LoginGoogle()
        //{
        //    //Enviar a Google
        //    string urlRetorno = Url.Action("GoogleResponse", "Login");
        //    var propiedades = _manager.ConfigureExternalAuthenticationProperties("Google", urlRetorno);
        //    return new ChallengeResult("Google", propiedades);
        //}

        //public async Task<IActionResult> GoogleResponse()
        //{
        //    //Recibir de Google
        //    ExternalLoginInfo res = await _manager.GetExternalLoginInfoAsync();

        //    //Usuario u = new Usuario()
        //    //{
        //    //    NombreCompleto = res.Principal.Claims.ElementAt(2).Value,
        //    //    Login = res.Principal.Claims.ElementAt(4).Value,
        //    //    Clave = "",
        //    //    Origen = "GOOGLE"
        //    //};

        //    //Por revisar
        //    UsuarioDTO u = new UsuarioDTO()
        //    {
        //        IdTip = 4,
        //        IdPer = 1,
        //        Usuario = res.Principal.Claims.ElementAt(4).Value,
        //        Contrasenia = "",
        //        Estado = true
        //    };

        //    UsuarioDTO usuario = _usuarioService.Insertar(u);

        //    if (usuario == null)
        //    {
        //        ModelState.AddModelError("*", "Credenciales invalidas");
        //        return View(usuario);
        //    }
        //    else
        //    {
        //        //grabarlo en sesion 
        //        HttpContext.Session.SetString("login", usuario.Usuario);
        //        usuario.Contrasenia = "";
        //        string usuariotexto = JsonConvert.SerializeObject(usuario);
        //        HttpContext.Session.SetString("user", usuariotexto);
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
    }
}