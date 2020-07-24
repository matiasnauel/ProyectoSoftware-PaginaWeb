using CapaDeDominio.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDominio.Queries
{
    public interface IQueryVenta
    {
        Task<ClienteDTOs> GetClienteID(int cliente);
        Task<CarritoDTOs> getCarritoCliente(int carrito);
    }
}
