using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NisiulInfoSoft.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<UsuarioDTO> Listar()
        {
            return _usuarioRepository.Listar();
        }

        public IQueryable ListarQueryable()
        {
            return _usuarioRepository.ListarQueryable();
        }

        public UsuarioDTO ObtenerPorId(int id)
        {
            return _usuarioRepository.ObtenerPorId(id);
        }

        public UsuarioDTO Insertar(UsuarioDTO usuario)
        {
            return _usuarioRepository.Insertar(usuario);
        }

        public UsuarioDTO Actualizar(UsuarioDTO usuario)
        {
            return _usuarioRepository.Actualizar(usuario);
        }

        public bool Eliminar(int id)
        {
            return _usuarioRepository.Eliminar(id);
        }

        public UsuarioDTO IniciarSesion(string login, string clave)
        {
            return _usuarioRepository.IniciarSesion(login, clave);
        }
    }
}
