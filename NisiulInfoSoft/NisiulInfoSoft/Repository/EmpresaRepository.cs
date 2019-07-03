using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NisiulInfoSoft.Context;
using NisiulInfoSoft.DTO;

namespace NisiulInfoSoft.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private NisiulInfoSoftContext _contexto;

        public EmpresaRepository(NisiulInfoSoftContext contexto)
        {
            _contexto = contexto;
        }

        public List<EmpresaDTO> Listar()
        {
            return _contexto.Empresa.ToList();
        }

        public IQueryable ListarPorRUC(string ruc)
        {
            return _contexto.Empresa
                .Where(e => e.Ruc.Contains(ruc))
                .Select(e => new {
                    e.IdEmp,
                    e.Ruc,
                    e.RazonSocial,
                    e.FechaRegistro,
                    e.FechaInicio,
                    e.Direccion,
                    e.Telefono,
                    e.Correo,
                    e.PaginaWeb,
                    e.Pais,
                    e.Departamento,
                    e.Distrito,
                    e.Observacion,
                    e.Estado
                })
                .OrderBy(e => e.RazonSocial);
        }

        public EmpresaDTO ObtenerPorId(int id)
        {
            return _contexto.Empresa.FirstOrDefault(e => e.IdEmp == id);
        }

        public IQueryable ObtenerPorRUC(string ruc)
        {
            return _contexto.Empresa
                .Where(e => e.Ruc.Equals(ruc))
                .Select(e => new
                {
                    e.IdEmp,
                    e.Ruc,
                    e.RazonSocial,
                    e.FechaRegistro,
                    e.FechaInicio,
                    e.Direccion,
                    e.Telefono,
                    e.Correo,
                    e.PaginaWeb,
                    e.Pais,
                    e.Departamento,
                    e.Distrito,
                    e.Observacion,
                    e.Estado
                });
        }

        public EmpresaDTO Insertar(EmpresaDTO empresa)
        {
            try
            {
                _contexto.Add(empresa);
                _contexto.SaveChanges();

                return empresa;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public EmpresaDTO Actualizar(EmpresaDTO empresa)
        {
            try
            {
                _contexto.Update(empresa);
                _contexto.SaveChanges();

                return empresa;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var empresa = _contexto.Empresa.FirstOrDefault(e => e.IdEmp == id);

                if (empresa != null)
                {
                    _contexto.Remove(empresa);

                    _contexto.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }
}
