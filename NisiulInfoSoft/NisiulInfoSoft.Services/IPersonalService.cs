using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NisiulInfoSoft.Services
{
    public interface IPersonalService
    {
        List<PersonalDTO> Listar();

        IQueryable ListarPorDNI(string dni);

        PersonalDTO ObtenerPorId(int id);

        IQueryable ObtenerPorDNI(string dni);

        PersonalDTO Insertar(PersonalDTO personal);

        PersonalDTO Actualizar(PersonalDTO personal);

        bool Eliminar(int id);
    }
}
