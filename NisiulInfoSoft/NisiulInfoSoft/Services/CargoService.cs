using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Repository;

namespace NisiulInfoSoft.Services
{
    public class CargoService : ICargoService
    {
        private ICargoRepository _cargoRepository;

        public CargoService(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public List<CargoDTO> Listar()
        {
            return _cargoRepository.Listar();
        }

        public CargoDTO ObtenerPorId(int id)
        {
            return _cargoRepository.ObtenerPorId(id);
        }

        public CargoDTO Insertar(CargoDTO cargo)
        {
            return _cargoRepository.Insertar(cargo);
        }

        public CargoDTO Actualizar(CargoDTO cargo)
        {
            return _cargoRepository.Actualizar(cargo);
        }

        public bool Eliminar(int id)
        {
            return _cargoRepository.Eliminar(id);
        }

    }
}
