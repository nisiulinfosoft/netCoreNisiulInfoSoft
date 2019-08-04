using Microsoft.EntityFrameworkCore;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.API.Microservicios.Context
{
    public class NisiulInfoSoftContext : DbContext
    {
        public NisiulInfoSoftContext
            (DbContextOptions<NisiulInfoSoftContext> options)
                : base(options)
        {

        }

        public DbSet<Pedido> Pedido { get; set; }
    }
}
