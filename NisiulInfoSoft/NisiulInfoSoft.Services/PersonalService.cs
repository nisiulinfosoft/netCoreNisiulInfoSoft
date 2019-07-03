using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NisiulInfoSoft.Services
{
    public class PersonalService : IPersonalService
    {

        private IPersonalRepository _personalRepository;

        public PersonalService(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }

        public List<PersonalDTO> Listar()
        {
            return _personalRepository.Listar();
        }

        public IQueryable ListarPorDNI(string dni)
        {
            return _personalRepository.ListarPorDNI(dni);
        }

        public PersonalDTO ObtenerPorId(int id)
        {
            return _personalRepository.ObtenerPorId(id);
        }

        public IQueryable ObtenerPorDNI(string dni)
        {
            return _personalRepository.ObtenerPorDNI(dni);
        }

        public PersonalDTO Insertar(PersonalDTO personal)
        {
            return _personalRepository.Insertar(personal);
        }

        public PersonalDTO Actualizar(PersonalDTO personal)
        {
            return _personalRepository.Actualizar(personal);
        }

        public bool Eliminar(int id)
        {
            return _personalRepository.Eliminar(id);
        }

    }
}
