using CapaDeDominio.Commands;
using CapaDeDominio.DTOs;
using CapaDeDominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace CapaDeAplicacion.Services
{
    public interface IDestinoVentas
    {
        DestinoVenta CreateVenta(DestinoVentaDTOs destinoventa);
        ICollection<DestinoVenta> GetDesintoVenta();
        bool DeleteDestinoVenta(DestinoVentaDTOs destino);
        bool UpdateDestinoVenta(DestinoVentaDTOs destino);
        DestinoVenta GetId(int id);
    }
    public class DestinoVentaService : IDestinoVentas
    {
        private readonly IGenericRepository _repository;

        public DestinoVentaService(IGenericRepository repositorio)
        {
            _repository = repositorio;
        }
        public DestinoVenta CreateVenta(DestinoVentaDTOs destinoventa)
        {
            var entity = new DestinoVenta()
            {
                Destino = destinoventa.Destino,
                Nombre = destinoventa.Nombre,
                Descripcion = destinoventa.Descripcion
            };
            _repository.Add(entity);
            return entity;
        }

        public bool DeleteDestinoVenta(DestinoVentaDTOs destino)
        {
            var entity = new DestinoVenta()
            {
                Id= destino.Id,
                Destino = destino.Destino,
                Nombre = destino.Nombre,
                Descripcion = destino.Descripcion
            };
            return _repository.Delete<DestinoVenta>(entity);
            
        }

        public ICollection<DestinoVenta> GetDesintoVenta()
        {
            return _repository.GetALL<DestinoVenta>().ToList();
        }

        public DestinoVenta GetId(int id)
        {
            return _repository.GetBy<DestinoVenta>(id);
        }

        public bool UpdateDestinoVenta(DestinoVentaDTOs destino)
        {
            var entity = new DestinoVenta()
            {
                Id = destino.Id,
                Destino = destino.Destino,
                Nombre = destino.Nombre,
                Descripcion = destino.Descripcion
            };
            return _repository.Update<DestinoVenta>(entity);

        }
    }
}
