using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NisiulInfoSoft.Services
{
    public interface IAreaService
    {
        List<AreaDTO> Listar();

        IQueryable ListarQueryable();

        List<AreaDTO> ListarQuery();

        List<AreaDTO> ListarQueryParametro(string descripcion);

        IQueryable ListarLinqQuery();

        List<AreaDTO> ListarCommand(string descripcion);

        List<AreaDTO> ListarSP();

        List<AreaDTO> ListarSPParametro(string descripcion);

        List<AreaDTO> ListarSPCommand(string descripcion);

        AreaDTO ObtenerPorId(int id);

        AreaDTO Insertar(AreaDTO area);

        AreaDTO InsertarExecuteSqlCommand(AreaDTO area);

        string InsertarExecuteSqlCommandOut(AreaDTO area);

        string InsertarCommand(AreaDTO area);

        string InsertarCommandOut(AreaDTO area);

        AreaDTO Actualizar(AreaDTO area);

        bool Eliminar(int id);

    }
}
