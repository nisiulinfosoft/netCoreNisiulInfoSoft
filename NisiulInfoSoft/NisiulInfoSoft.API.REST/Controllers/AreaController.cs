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
    public class AreaController : ControllerBase
    {
        private IAreaService _areaService;
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var areas = _areaService.Listar();

            return Ok(areas);
        }

        [HttpGet]
        public IActionResult ListarQueryable()
        {
            var areas = _areaService.ListarQueryable();

            return Ok(areas);
        }

        [HttpGet]
        public IActionResult ListarQuery()
        {
            var areas = _areaService.ListarQuery();

            return Ok(areas);
        }

        [HttpGet]
        public IActionResult ListarQueryParametro(string descripcion)
        {
            var areas = _areaService.ListarQueryParametro(descripcion);

            return Ok(areas);
        }

        [HttpGet]
        public IActionResult ListarLinqQuery()
        {
            var areas = _areaService.ListarLinqQuery();

            return Ok(areas);
        }

        [HttpGet]
        public IActionResult ListarCommand(string descripcion)
        {
            var areas = _areaService.ListarCommand(descripcion);

            return Ok(areas);
        }

        [HttpGet]
        public IActionResult ListarSP()
        {
            var areas = _areaService.ListarSP();

            return Ok(areas);
        }

        [HttpGet]
        public IActionResult ListarSPParametro(string descripcion)
        {
            var areas = _areaService.ListarSPParametro(descripcion);

            return Ok(areas);
        }

        [HttpGet]
        public IActionResult ListarSPCommand(string descripcion)
        {
            var areas = _areaService.ListarSPCommand(descripcion);

            return Ok(areas);
        }

        [HttpGet]
        public IActionResult Recuperar(int id)
        {
            var area = _areaService.ObtenerPorId(id);

            if (area == null)
            {
                return BadRequest("El codigo que enviaste no existe");
            }

            return Ok(area);
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] AreaDTO area)
        {
            if (area == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (string.IsNullOrEmpty(area.Descripcion))
            {
                return BadRequest("Debe enviar descripción");
            }

            var areaInsertar = _areaService.Insertar(area);

            return Ok(areaInsertar);

        }

        [HttpPost]
        public IActionResult InsertarExecuteSqlCommand([FromBody] AreaDTO area)
        {
            if (area == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (string.IsNullOrEmpty(area.Descripcion))
            {
                return BadRequest("Debe enviar descripción");
            }

            var areaInsertar = _areaService.InsertarExecuteSqlCommand(area);

            return Ok(areaInsertar);

        }

        [HttpPost]
        public IActionResult InsertarExecuteSqlCommandOut([FromBody] AreaDTO area)
        {
            if (area == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (string.IsNullOrEmpty(area.Descripcion))
            {
                return BadRequest("Debe enviar descripción");
            }

            var areaInsertar = _areaService.InsertarExecuteSqlCommandOut(area);

            return Ok(areaInsertar);

        }

        [HttpPost]
        public IActionResult InsertarCommand([FromBody] AreaDTO area)
        {
            if (area == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (string.IsNullOrEmpty(area.Descripcion))
            {
                return BadRequest("Debe enviar descripción");
            }

            var areaInsertar = _areaService.InsertarCommand(area);

            return Ok(areaInsertar);

        }

        [HttpPost]
        public IActionResult InsertarCommandOut([FromBody] AreaDTO area)
        {
            if (area == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (string.IsNullOrEmpty(area.Descripcion))
            {
                return BadRequest("Debe enviar descripción");
            }

            var areaInsertar = _areaService.InsertarCommandOut(area);

            return Ok(areaInsertar);

        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] AreaDTO area)
        {
            if (area == null)
            {
                return BadRequest("Debe enviar datos");
            }

            if (area.IdAre == 0)
            {
                return BadRequest("Debe enviar id");
            }

            if (string.IsNullOrEmpty(area.Descripcion))
            {
                return BadRequest("Debe enviar descripción");
            }

            var areaActualizar = _areaService.Actualizar(area);

            if (areaActualizar == null)
            {
                return BadRequest("Área no actualizada");
            }

            return Ok(areaActualizar);

        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var areaEliminar = _areaService.Eliminar(id);

            if (areaEliminar == false)
            {
                return BadRequest("Área no eliminada");
            }

            return Ok("Área eliminada");
        }
    }
}
