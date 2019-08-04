using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Publisher.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SenderController : ControllerBase
    {
        private readonly ServiceBusTopicSender sender;

        public SenderController(ServiceBusTopicSender _sender)
        {
            sender = _sender;
        }

        [HttpPost]
        public async Task<IActionResult> GrabarPedido([FromBody] Pedido request)
        {
            await sender.SendMessage(request);

            return Ok("Su pedido se recibio");
        }
    }
}
