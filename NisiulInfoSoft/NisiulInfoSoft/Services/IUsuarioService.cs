using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.Services
{
    public interface IUsuarioService
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
