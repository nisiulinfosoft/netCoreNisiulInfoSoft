using NisiulInfoSoft.Context;
using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.Services
{
    public class AreaService : IAreaService
    {
        private IAreaRepository _areaRepository;

        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public List<AreaDTO> Listar()
        {
            return _areaRepository.Listar();
        }

        public IQueryable ListarQueryable()
        {
            return _areaRepository.ListarQueryable();
        }

        public List<AreaDTO> ListarQuery()
        {
            return _areaRepository.ListarQuery();
        }

        public List<AreaDTO> ListarQueryParametro(string descripcion)
        {
            return _areaRepository.ListarQueryParametro(descripcion);
        }

        public IQueryable ListarLinqQuery()
        {
            return _areaRepository.ListarLinqQuery();
        }

        public List<AreaDTO> ListarCommand(string descripcion)
        {
            return _areaRepository.ListarCommand(descripcion);
        }

        public List<AreaDTO> ListarSP()
        {
            return _areaRepository.ListarSP();
        }

        public List<AreaDTO> ListarSPParametro(string descripcion)
        {
            return _areaRepository.ListarSPParametro(descripcion);
        }

        public List<AreaDTO> ListarSPCommand(string descripcion)
        {
            return _areaRepository.ListarSPCommand(descripcion);
        }

        public AreaDTO ObtenerPorId(int id)
        {
            return _areaRepository.ObtenerPorId(id);
        }

        public AreaDTO Insertar(AreaDTO area)
        {
            return _areaRepository.Insertar(area);
        }

        public AreaDTO InsertarExecuteSqlCommand(AreaDTO area)
        {
            return _areaRepository.InsertarExecuteSqlCommand(area);
        }

        public string InsertarExecuteSqlCommandOut(AreaDTO area)
        {
            return _areaRepository.InsertarExecuteSqlCommandOut(area);
        }

        public string InsertarCommand(AreaDTO area)
        {
            return _areaRepository.InsertarCommand(area);
        }

        public string InsertarCommandOut(AreaDTO area)
        {
            return _areaRepository.InsertarCommandOut(area);
        }

        public AreaDTO Actualizar(AreaDTO area)
        {
            return _areaRepository.Actualizar(area);
        }

        public bool Eliminar(int id)
        {
            return _areaRepository.Eliminar(id);
        }
    }
}
