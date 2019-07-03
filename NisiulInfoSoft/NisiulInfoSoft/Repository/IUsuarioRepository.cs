using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.Repository
{
    public interface IUsuarioRepository
    {
        List<UsuarioDTO> Listar();

        IQueryable ListarQueryable();

        UsuarioDTO ObtenerPorId(int id);

        UsuarioDTO Insertar(UsuarioDTO usuario);

        UsuarioDTO Actualizar(UsuarioDTO usuario);

        bool Eliminar(int id);

        UsuarioDTO IniciarSesion(string login, string clave);
    }
}
