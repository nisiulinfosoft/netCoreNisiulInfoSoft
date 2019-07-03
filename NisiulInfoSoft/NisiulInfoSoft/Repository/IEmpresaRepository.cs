using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.Repository
{
    public interface IEmpresaRepository
    {
        List<EmpresaDTO> Listar();

        IQueryable ListarPorRUC(string ruc);

        EmpresaDTO ObtenerPorId(int id);

        IQueryable ObtenerPorRUC(string ruc);

        EmpresaDTO Insertar(EmpresaDTO empresa);

        EmpresaDTO Actualizar(EmpresaDTO empresa);

        bool Eliminar(int id);
    }
}
