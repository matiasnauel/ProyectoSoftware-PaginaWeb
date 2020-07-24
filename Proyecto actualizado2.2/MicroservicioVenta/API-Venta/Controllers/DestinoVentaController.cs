using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDeAplicacion.Services;
using CapaDeDominio.DTOs;
using CapaDeDominio.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoVentaController : ControllerBase
    {
        private readonly IDestinoVentas _service;
        public DestinoVentaController(IDestinoVentas servicio)
        {
            _service = servicio;
        }
        [HttpPost]
        public IActionResult Post(DestinoVentaDTOs destinoventa)
        {
            try
            {
                return new JsonResult(_service.CreateVenta(destinoventa)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(_service.GetDesintoVenta()) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(DestinoVentaDTOs destino)
        {
            try
            {
                return new JsonResult(_service.DeleteDestinoVenta(destino)) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(DestinoVentaDTOs destino)
        {
            try
            {
                return new JsonResult(_service.UpdateDestinoVenta(destino)) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("getID")]
        public IActionResult getID([FromQuery]int id)
        {
            try
            {
                return new JsonResult(_service.GetId(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}