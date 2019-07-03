using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NisiulInfosoft.EF.CodeFirst.Entities;
using System;
using System.IO;
using System.Linq;

namespace NisiulInfosoft.EF.CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var cntx = new NisiulInfosoftContext();

            Console.WriteLine("Hello World!");

            //-----------------------------------------------------------------------------------------------
            Console.WriteLine("Lista de áreas con Repository");
            Console.WriteLine("============================");

            var areas = cntx.NisArea.Select(a => new { a.IdAre, a.Descripcion, a.Observacion, a.Estado });

            //areas.ForEach(area =>
            //{
            //    Console.WriteLine(area.Descripcion);
            //});

            foreach (var item in areas)
            {
                Console.WriteLine(item.Descripcion);
            }

            //-----------------------------------------------------------------------------------------------
            Console.WriteLine("\nLista de áreas con SP");
            Console.WriteLine("====================");

            var areas2 = cntx.NisArea.FromSql("NISUSP_AREA_LIST").ToList();

            //areas.ForEach(area =>
            //{
            //    Console.WriteLine(area.Descripcion);
            //});

            foreach (var item in areas2)
            {
                Console.WriteLine(item.Descripcion);
            }

            //-----------------------------------------------------------------------------------------------
            Console.WriteLine("\nLista de áreas con Command");
            Console.WriteLine("===========================");

            var command = cntx.Database.GetDbConnection().CreateCommand();
            command.CommandText = "SELECT * FROM NIS_AREA";
            cntx.Database.OpenConnection();

            try
            {
                var result = command.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Console.WriteLine(result.GetString(1));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                cntx.Database.CloseConnection();
            }

            Console.ReadKey();
        }




    }
}
