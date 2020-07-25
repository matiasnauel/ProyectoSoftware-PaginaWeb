using CapaDeDominio.Commands;
using CapaDeDominio.DTOs;
using CapaDeDominio.Entity;
using CapaDeDominio.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeAplicacion.Services
{

    public interface IVentaService
    {
     
      
      
    }
    public class VentaService : IVentaService
    {
        private readonly IGenericRepository _repository;
        private readonly IQueryVenta query;

        public VentaService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public VentaService(IGenericRepository repository, IQueryVenta query)
        {
            _repository = repository;
            this.query = query;
        }

       

        public ICollection<Venta> GetVenta()
        {
            return _repository.GetALL<Venta>().ToList();
        }

        public Venta GetId(int id)
        {
            return _repository.GetBy<Venta>(id);
        }

     

     
    }
}
