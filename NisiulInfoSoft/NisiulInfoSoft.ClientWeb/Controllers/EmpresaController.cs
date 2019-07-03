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
    public class EmpresaController : Controller
    {
        private IEmpresaService _empresaService;
        private EstadoModel estado;
        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
            estado = new EstadoModel();
        }

        public IActionResult Index()
        {
            return View(_empresaService.Listar());
        }

        [HttpGet]
        public IActionResult Editar(int id = 0)
        {
            EmpresaDTO empresa;

            if (id == 0) //nuevo
            {
                empresa = new EmpresaDTO();
            }
            else //editar
            {
                empresa = _empresaService.ObtenerPorId(id);
            }

            ViewBag.listItemsEstados = estado.listItemsEstados;

            return View(empresa);
        }

        [HttpGet]
        public IActionResult Detalle(int id = 0)
        {
            EmpresaDTO empresa;

            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            empresa = _empresaService.ObtenerPorId(id);

            if (empresa == null)
            {
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        [HttpPost]
        public IActionResult Grabar(EmpresaDTO empresa)
        {
            if (empresa.IdEmp == 0)
            {
                _empresaService.Insertar(empresa);
            }
            else
            {
                _empresaService.Actualizar(empresa);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id = 0)
        {
            _empresaService.Eliminar(id);

            return RedirectToAction("Index");
        }
    }
}