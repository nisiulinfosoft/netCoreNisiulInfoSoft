using NisiulInfoSoft.Context;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NisiulInfoSoft.Repository
{
    public class PersonalRepository : IPersonalRepository
    {
        private NisiulInfoSoftContext _contexto;

        public PersonalRepository(NisiulInfoSoftContext contexto)
        {
            _contexto = contexto;
        }

        public List<PersonalDTO> Listar()
        {
            return _contexto.Personal.ToList();
        }

        public IQueryable ListarPorDNI(string dni)
        {
            return _contexto.Personal.Where(p => p.Dni.Contains(dni))
                .Select(p => new {
                    p.IdPer,
                    p.IdEmp,
                    p.IdAre,
                    p.IdCar,
                    p.Dni,
                    p.Nombre,
                    p.ApellidoPaterno,
                    p.ApellidoMaterno,
                    p.Sexo,
                    p.FechaRegistro,
                    p.FechaNacimiento,
                    p.FechaContacto,
                    p.Telefono,
                    p.Celular,
                    p.Correo,
                    p.Direccion,
                    p.Observacion,
                    p.Estado
                })
                .OrderBy(p => p.ApellidoPaterno);
        }

        public PersonalDTO ObtenerPorId(int id)
        {
            return _contexto.Personal.FirstOrDefault(p => p.IdPer == id);
        }

        public IQueryable ObtenerPorDNI(string dni)
        {
            return _contexto.Personal
                .Where(p => p.Dni.Equals(dni))
                .Select(p => new {
                    p.IdPer,
                    p.IdEmp,
                    p.IdAre,
                    p.IdCar,
                    p.Dni,
                    p.Nombre,
                    p.ApellidoPaterno,
                    p.ApellidoMaterno,
                    p.Sexo,
                    p.FechaRegistro,
                    p.FechaNacimiento,
                    p.FechaContacto,
                    p.Telefono,
                    p.Celular,
                    p.Correo,
                    p.Direccion,
                    p.Observacion,
                    p.Estado
                });
        }

        public PersonalDTO Insertar(PersonalDTO personal)
        {
            try
            {
                _contexto.Add(personal);
                _contexto.SaveChanges();

                return personal;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PersonalDTO Actualizar(PersonalDTO personal)
        {
            try
            {
                _contexto.Update(personal);
                _contexto.SaveChanges();

                return personal;
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
                var personal = _contexto.Personal.FirstOrDefault(p => p.IdPer == id);

                if (personal != null)
                {
                    _contexto.Remove(personal);

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
