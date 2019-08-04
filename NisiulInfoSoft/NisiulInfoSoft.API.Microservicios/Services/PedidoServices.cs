using NisiulInfoSoft.API.Microservicios.Context;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.API.Microservicios.Services
{
    public class PedidoServices : IPedidoServices
    {
        private readonly NisiulInfoSoftContext contexto;

        public PedidoServices(NisiulInfoSoftContext _contexto)
        {
            contexto = _contexto;
        }
        public Pedido Insertar(Pedido pedido)
        {
            contexto.Pedido.Add(pedido);
            contexto.SaveChanges();
            return pedido;
        }

        public List<Pedido> Listar()
        {
            return contexto.Pedido.ToList();
        }

        public Pedido Recuperar(int id)
        {
            return contexto.Pedido.FirstOrDefault(t => t.IdPedido == id);
        }
    }
}
