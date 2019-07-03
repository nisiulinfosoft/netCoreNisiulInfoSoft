using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NisiulInfoSoft.Context;
using NisiulInfoSoft.DTO;

namespace NisiulInfoSoft.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private NisiulInfoSoftContext _contexto;

        public TipoUsuarioRepository(NisiulInfoSoftContext contexto)
        {
            _contexto = contexto;
        }

        public List<TipoUsuarioDTO> Listar()
        {
            return _contexto.TipoUsuario.ToList();
        }

        public IQueryable ListarQueryable()
        {
            return _contexto.TipoUsuario.Select(t => new { t.IdTip, t.Descripcion, t.Observacion, t.Estado })
                .OrderBy(t => t.Descripcion);
        }

        public TipoUsuarioDTO ObtenerPorId(int id)
        {
            return _contexto.TipoUsuario.FirstOrDefault(t => t.IdTip == id);
        }

        public TipoUsuarioDTO Insertar(TipoUsuarioDTO tipoUsuario)
        {
            try
            {
                _contexto.Add(tipoUsuario);
                _contexto.SaveChanges();

                return tipoUsuario;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TipoUsuarioDTO Actualizar(TipoUsuarioDTO tipoUsuario)
        {
            try
            {
                _contexto.Update(tipoUsuario);
                _contexto.SaveChanges();

                return tipoUsuario;
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
                var tipoUsuario = _contexto.TipoUsuario.FirstOrDefault(t => t.IdTip == id);

                if (tipoUsuario != null)
                {
                    _contexto.Remove(tipoUsuario);

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
