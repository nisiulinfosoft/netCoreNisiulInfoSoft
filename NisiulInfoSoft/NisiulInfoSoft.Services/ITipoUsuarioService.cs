using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NisiulInfoSoft.Services
{
    public interface ITipoUsuarioService
    {
        List<TipoUsuarioDTO> Listar();

        IQueryable ListarQueryable();

        TipoUsuarioDTO ObtenerPorId(int id);

        TipoUsuarioDTO Insertar(TipoUsuarioDTO tipoUsuario);

        TipoUsuarioDTO Actualizar(TipoUsuarioDTO tipoUsuario);

        bool Eliminar(int id);
    }
}
