using CapaDeDominio.Commands;
using CapaDeDominio.DTOs;
using CapaDeDominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDeAplicacion.Services
{
    public interface IVentaReclamoService
    {
        VentaReclamo CrearVentaReclamo(VentaReclamoDTOs venta);
        ICollection<VentaReclamo> GetVentaReclamo();
        bool DeleteReclamo(VentaReclamoDTOs ventareclamo);
        bool UpdateVentaReclamo(VentaReclamoDTOs ventareclamo);
        VentaReclamo GetId(int id);
    }
    public class VentaReclamoService : IVentaReclamoService
    {
        private readonly IGenericRepository _repository;
        public VentaReclamoService(IGenericRepository repositorio)
        {
            _repository = repositorio;
        }
        public VentaReclamo CrearVentaReclamo(VentaReclamoDTOs venta)
        {
            var entity = new VentaReclamo()
            {
                Reclamo = venta.Reclamo
            
            };
            _repository.Add<VentaReclamo>(entity);
            return entity;
        }

        public bool DeleteReclamo(VentaReclamoDTOs ventareclamo)
        {
            var entity = new VentaReclamo()
            {
                Id = ventareclamo.Id,
                Reclamo = ventareclamo.Reclamo

            };
            return _repository.Delete<VentaReclamo>(entity);
            
        }

        public VentaReclamo GetId(int id)
        {
            return _repository.GetBy<VentaReclamo>(id);
        }

        public ICollection<VentaReclamo> GetVentaReclamo()
        {
            return _repository.GetALL<VentaReclamo>().ToList();
        }

        public bool UpdateVentaReclamo(VentaReclamoDTOs ventareclamo)
        {
            var entity = new VentaReclamo()
            {
                Id = ventareclamo.Id,
                Reclamo = ventareclamo.Reclamo

            };
            return _repository.Update<VentaReclamo>(entity);
        }
    }
}
