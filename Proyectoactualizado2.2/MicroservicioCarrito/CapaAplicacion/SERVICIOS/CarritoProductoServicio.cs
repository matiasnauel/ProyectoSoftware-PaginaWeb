using CapaDominio.COMANDOS;
using CapaDominio.ENTIDADES;
using CapaDominio.QUERYS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaAplicacion.SERVICIOS
{
    public interface ICarritoProductoServicio
    {
        CarritoProducto InsertarCarritoProductoCliente(int carritoID,int productoID);
    }

    public class CarritoProductoServicio: ICarritoProductoServicio
    {

        private readonly IGenericsRepository repository;
        private readonly IQueryCarritoProducto query;

        public CarritoProductoServicio(IGenericsRepository repository, IQueryCarritoProducto query)
        {
            this.repository = repository;
            this.query = query;
        }

        public CarritoProducto InsertarCarritoProductoCliente(int carritoID, int productoID)
        {
            CarritoProducto objeto = new CarritoProducto()
            {
                CarritoID=carritoID,
                ProductoID=productoID
            };

            return repository.Agregar<CarritoProducto>(objeto);
        }
    }
}
