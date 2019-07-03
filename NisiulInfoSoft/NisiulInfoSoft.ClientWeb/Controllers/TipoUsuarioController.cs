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
    public class TipoUsuarioController : Controller
    {
        private ITipoUsuarioService _tipoUsuarioService;
        private EstadoModel estado;
        public TipoUsuarioController(ITipoUsuarioService tipoUsuarioService)
        {
            _tipoUsuarioService = tipoUsuarioService;
            estado = new EstadoModel();
        }

        public IActionResult Index()
        {
            return View(_tipoUsuarioService.Listar());
        }

        [HttpGet]
        public IActionResult Editar(int id = 0)
        {
            TipoUsuarioDTO tipoUsuario;

            if (id == 0) //nuevo
            {
                tipoUsuario = new TipoUsuarioDTO();
            }
            else //editar
            {
                tipoUsuario = _tipoUsuarioService.ObtenerPorId(id);
            }

            ViewBag.listItemsEstados = estado.listItemsEstados;

            return View(tipoUsuario);
        }

        [HttpPost]
        public IActionResult Grabar(TipoUsuarioDTO tipoUsuario)
        {
            if (tipoUsuario.IdTip == 0)
            {
                _tipoUsuarioService.Insertar(tipoUsuario);
            }
            else
            {
                _tipoUsuarioService.Actualizar(tipoUsuario);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id = 0)
        {
            _tipoUsuarioService.Eliminar(id);

            return RedirectToAction("Index");
        }
    }
}