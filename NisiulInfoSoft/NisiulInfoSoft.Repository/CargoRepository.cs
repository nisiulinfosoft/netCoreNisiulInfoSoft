using NisiulInfoSoft.Context;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NisiulInfoSoft.Repository
{
    public class CargoRepository : ICargoRepository
    {
        private NisiulInfoSoftContext _contexto;

        public CargoRepository(NisiulInfoSoftContext contexto)
        {
            _contexto = contexto;
        }

        public List<CargoDTO> Listar()
        {
            return _contexto.Cargo.ToList();
        }

        public CargoDTO ObtenerPorId(int id)
        {
            return _contexto.Cargo.FirstOrDefault(c => c.IdCar == id);
        }

        public CargoDTO Insertar(CargoDTO cargo)
        {
            try
            {
                _contexto.Add(cargo);
                _contexto.SaveChanges();

                return cargo;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public CargoDTO Actualizar(CargoDTO cargo)
        {
            try
            {
                _contexto.Update(cargo);
                _contexto.SaveChanges();

                return cargo;
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
                var cargo = _contexto.Cargo.FirstOrDefault(c => c.IdCar == id);

                if (cargo != null)
                {
                    _contexto.Remove(cargo);

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
