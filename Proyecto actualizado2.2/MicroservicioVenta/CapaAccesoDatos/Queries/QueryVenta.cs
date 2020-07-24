using CapaDeDominio.DTOs;
using CapaDeDominio.Queries;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace CapaAccesoDatos.Queries
{
    public class QueryVenta : IQueryVenta
    {
        private readonly Compiler compiler;
        private readonly IDbConnection connection;

        public QueryVenta(Compiler compiler, IDbConnection connection)
        {
            this.compiler = compiler;
            this.connection = connection;
        }


        //buscar un carrito por su id
        public async Task<CarritoDTOs> getCarritoCliente(int carrito)
        {
            
            var url = "https://localhost:44342/api/Carrito?carrito=" + carrito;
            using (var http = new HttpClient())
            {
                var response = await http.GetStringAsync(url);
                var get = JsonConvert.DeserializeObject<CarritoDTOs>(response);
                return get;
            }
        }
        //buscar un cliente por su idd
        public async Task<ClienteDTOs> GetClienteID(int cliente)
        {
           
            var url = "https://localhost:44368/api/Cliente?cliente="+cliente;
            using (var http = new HttpClient())
            {
                var response = await http.GetStringAsync(url);
                var get = JsonConvert.DeserializeObject<ClienteDTOs>(response);
                return get;
            }
        }
    }
}
