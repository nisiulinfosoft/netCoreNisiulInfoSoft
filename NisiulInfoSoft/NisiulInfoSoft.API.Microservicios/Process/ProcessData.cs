using Microsoft.EntityFrameworkCore;
using NisiulInfoSoft.API.Microservicios.Context;
using NisiulInfoSoft.API.Microservicios.Helpers;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.API.Microservicios.Process
{
    public class ProcessData : IProcessData
    {
        public void Process(Pedido myPayload)
        {
            var optionBuilder = new DbContextOptionsBuilder<NisiulInfoSoftContext>();

            optionBuilder.UseSqlServer("Server=tcp:srvgalaxylema.database.windows.net,1433;Initial Catalog=bdventasgalaxy;Persist Security Info=False;User ID=galaxy;Password=A123456789123$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            using (NisiulInfoSoftContext contexto = new NisiulInfoSoftContext(optionBuilder.Options))
            {
                contexto.Pedido.Add(myPayload);
                contexto.SaveChanges();
            }

            string pruebas = "";
        }
    }
}
