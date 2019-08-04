using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.API.Microservicios.Services
{
    public interface IPedidoServices
    {
        List<Pedido> Listar();
        Pedido Recuperar(int id);
        Pedido Insertar(Pedido pedido);
    }
}
