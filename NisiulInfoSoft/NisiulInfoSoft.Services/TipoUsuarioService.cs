using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NisiulInfoSoft.Services
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioService(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        public List<TipoUsuarioDTO> Listar()
        {
            return _tipoUsuarioRepository.Listar();
        }

        public IQueryable ListarQueryable()
        {
            return _tipoUsuarioRepository.ListarQueryable();
        }

        public TipoUsuarioDTO ObtenerPorId(int id)
        {
            return _tipoUsuarioRepository.ObtenerPorId(id);
        }

        public TipoUsuarioDTO Insertar(TipoUsuarioDTO tipoUsuario)
        {
            return _tipoUsuarioRepository.Insertar(tipoUsuario);
        }

        public TipoUsuarioDTO Actualizar(TipoUsuarioDTO tipoUsuario)
        {
            return _tipoUsuarioRepository.Actualizar(tipoUsuario);
        }

        public bool Eliminar(int id)
        {
            return _tipoUsuarioRepository.Eliminar(id);
        }

    }
}
