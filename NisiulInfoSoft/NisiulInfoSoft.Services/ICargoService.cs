using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NisiulInfoSoft.Services
{
    public interface ICargoService
    {
        List<CargoDTO> Listar();

        CargoDTO ObtenerPorId(int id);

        CargoDTO Insertar(CargoDTO cargo);

        CargoDTO Actualizar(CargoDTO cargo);

        bool Eliminar(int id);
    }
}
