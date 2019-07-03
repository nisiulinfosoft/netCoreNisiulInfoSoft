using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NisiulInfoSoft.Context;
using NisiulInfoSoft.DTO;

namespace NisiulInfoSoft.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private NisiulInfoSoftContext _contexto;

        public UsuarioRepository(NisiulInfoSoftContext contexto)
        {
            _contexto = contexto;
        }

        public List<UsuarioDTO> Listar()
        {
            return _contexto.Usuario.ToList();
        }

        public IQueryable ListarQueryable()
        {
            return _contexto.Usuario.Select(u => new { u.IdUsu, u.IdTip, u.IdPer, u.Usuario, u.Contrasenia, u.Estado })
                .OrderBy(u => u.Usuario);
        }

        public UsuarioDTO ObtenerPorId(int id)
        {
            return _contexto.Usuario.FirstOrDefault(u => u.IdUsu == id);
        }

        public UsuarioDTO Insertar(UsuarioDTO usuario)
        {
            try
            {
                _contexto.Add(usuario);
                _contexto.SaveChanges();

                return usuario;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public UsuarioDTO Actualizar(UsuarioDTO usuario)
        {
            try
            {
                _contexto.Update(usuario);
                _contexto.SaveChanges();

                return usuario;
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
                var usuario = _contexto.Usuario.FirstOrDefault(u => u.IdUsu == id);

                if (usuario != null)
                {
                    _contexto.Remove(usuario);

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

        public UsuarioDTO IniciarSesion(string login, string clave)
        {
            return _contexto.Usuario.FirstOrDefault(u => u.Usuario.Equals(login) && u.Contrasenia.Equals(clave));
        }
    }
}
