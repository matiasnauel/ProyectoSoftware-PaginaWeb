using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDeAplicacion.Services;
using CapaDeDominio.Commands;
using CapaDeDominio.DTOs;
using CapaDeDominio.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _servicio;
        public VentaController(IVentaService servicio)
        {
            _servicio = servicio;
        }
        [HttpPost]

        public IActionResult Post(VentaDTOs venta)
        {
            try
            {
                return new JsonResult(_servicio.CrearVenta(venta)) { StatusCode = 201 };
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(_servicio.GetVenta()) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
   
    
        [HttpGet("getID")]
        public IActionResult getID([FromQuery] int id)
        {
            try
            {
                return new JsonResult(_servicio.GetId(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult getCliente([FromQuery] int cliente)
        {
            try
            {
                return new JsonResult(_servicio.GetClienteID(cliente)) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult getCarritoCliente([FromQuery] int carrito)
        {
            try
            {
                return new JsonResult(_servicio.getCarritoCliente(carrito)) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}