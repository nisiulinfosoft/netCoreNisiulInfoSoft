using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NisiulInfoSoft.Services
{
    public class EmpresaService : IEmpresaService
    {
        private IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public List<EmpresaDTO> Listar()
        {
            return _empresaRepository.Listar();
        }

        public IQueryable ListarPorRUC(string ruc)
        {
            return _empresaRepository.ListarPorRUC(ruc);
        }

        public EmpresaDTO ObtenerPorId(int id)
        {
            return _empresaRepository.ObtenerPorId(id);
        }

        public IQueryable ObtenerPorRUC(string ruc)
        {
            return _empresaRepository.ObtenerPorRUC(ruc);
        }

        public EmpresaDTO Insertar(EmpresaDTO empresa)
        {
            return _empresaRepository.Insertar(empresa);
        }

        public EmpresaDTO Actualizar(EmpresaDTO empresa)
        {
            return _empresaRepository.Actualizar(empresa);
        }

        public bool Eliminar(int id)
        {
            return _empresaRepository.Eliminar(id);
        }

    }
}
