using Microsoft.AspNetCore.Mvc;
using NisiulInfoSoft.API.Microservicios.Services;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.API.Microservicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoServices services;

        public PedidoController(IPedidoServices _services)
        {
            this.services = _services;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(services.Listar());
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] Pedido pedido)
        {
            return Ok(services.Insertar(pedido));
        }
    }
}
