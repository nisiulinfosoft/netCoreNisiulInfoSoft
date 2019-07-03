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
    public class UsuarioController : Controller
    {
        private IUsuarioService _usuarioService;
        private ITipoUsuarioService _tipoUsuarioService;
        private IPersonalService _personalService;
        private EstadoModel estado;
        public UsuarioController(IUsuarioService usuarioService,
            ITipoUsuarioService tipoUsuarioService,
            IPersonalService personalService)
        {
            _usuarioService = usuarioService;
            _tipoUsuarioService = tipoUsuarioService;
            _personalService = personalService;
            estado = new EstadoModel();
        }

        public IActionResult Index()
        {
            return View(_usuarioService.Listar());
        }

        [HttpGet]
        public IActionResult Editar(int id = 0)
        {
            UsuarioDTO usuario;

            if (id == 0) //nuevo
            {
                usuario = new UsuarioDTO();
            }
            else //editar
            {
                usuario = _usuarioService.ObtenerPorId(id);
            }

            var listItemsTiposUsuarios = from e in _tipoUsuarioService.Listar()
                                    select new SelectListItem
                                    {
                                        Text = e.Descripcion,
                                        Value = e.IdTip.ToString()
                                    };

            var listItemsPersonal = from a in _personalService.Listar()
                                 select new SelectListItem
                                 {
                                     Text = a.Nombre + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno,
                                     Value = a.IdPer.ToString()
                                 };

            ViewBag.listItemsTiposUsuarios = listItemsTiposUsuarios;
            ViewBag.listItemsPersonal = listItemsPersonal;
            ViewBag.listItemsEstados = estado.listItemsEstados;

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Detalle(int id = 0)
        {
            UsuarioDTO usuario;

            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            usuario = _usuarioService.ObtenerPorId(id);

            if (usuario == null)
            {
                return RedirectToAction("Index");
            }

            var personal = _personalService.ObtenerPorId(usuario.IdPer);

            ViewBag.personal = personal.Nombre + " " + personal.ApellidoPaterno + " " + personal.ApellidoMaterno;
            ViewBag.tipoUsuario = _tipoUsuarioService.ObtenerPorId(usuario.IdTip).Descripcion;

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Grabar(UsuarioDTO t)
        {
            if (t.IdUsu == 0)
            {
                _usuarioService.Insertar(t);
            }
            else
            {
                _usuarioService.Actualizar(t);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id = 0)
        {
            _usuarioService.Eliminar(id);

            return RedirectToAction("Index");
        }
    }
}