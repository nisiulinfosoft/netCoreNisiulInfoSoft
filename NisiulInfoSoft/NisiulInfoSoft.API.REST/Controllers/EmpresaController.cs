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
    public class EmpresaController : ControllerBase
    {
        private IEmpresaService _empresaService;
        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var empresas = _empresaService.Listar();

            return Ok(empresas);
        }

        [HttpGet]
        public IActionResult ListarPorRUC(string ruc)
        {
            var empresas = _empresaService.ListarPorRUC(ruc);

            return Ok(empresas);
        }

        [HttpGet]
        public IActionResult Recuperar(int id)
        {
            var empresa = _empresaService.ObtenerPorId(id);

            if (empresa == null)
            {
                return BadRequest("El codigo que enviaste no existe");
            }

            return Ok(empresa);
        }

        [HttpGet]
        public IActionResult RecuperarPorRUC(string ruc)
        {
            var empresa = _empresaService.ObtenerPorRUC(ruc);

            if (empresa == null)
            {
                return BadRequest("El RUC que enviaste no existe");
            }

            return Ok(empresa);
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] EmpresaDTO empresa)
        {
            if (empresa == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (string.IsNullOrEmpty(empresa.Ruc))
            {
                return BadRequest("Debe enviar RUC");
            }

            if (string.IsNullOrEmpty(empresa.RazonSocial))
            {
                return BadRequest("Debe enviar Razón Social");
            }

            var empresaInsertar = _empresaService.Insertar(empresa);

            return Ok(empresaInsertar);

        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] EmpresaDTO empresa)
        {
            if (empresa == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (empresa.IdEmp == 0)
            {
                return BadRequest("Debe enviar id");
            }

            if (string.IsNullOrEmpty(empresa.Ruc))
            {
                return BadRequest("Debe enviar RUC");
            }

            if (string.IsNullOrEmpty(empresa.RazonSocial))
            {
                return BadRequest("Debe enviar Razón Social");
            }

            var empresaActualizar = _empresaService.Actualizar(empresa);

            if (empresaActualizar == null)
            {
                return BadRequest("Empresa no actualizada");
            }

            return Ok(empresaActualizar);

        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var empresaEliminar = _empresaService.Eliminar(id);

            if (empresaEliminar == false)
            {
                return BadRequest("Empresa no eliminada");
            }

            return Ok("Empresa eliminada");
        }
    }
}
