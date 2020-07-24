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
    public class VentaReclamoController : ControllerBase
    {
        private IVentaReclamoService _service;
        public VentaReclamoController(IVentaReclamoService servicio)
        {
            _service = servicio;
        }
        [HttpPost]
        public IActionResult Post(VentaReclamoDTOs ventareclamo)
        {
            try
            {
                return new JsonResult(_service.CrearVentaReclamo(ventareclamo)) { StatusCode = 201 };
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
                return new JsonResult(_service.GetVentaReclamo()) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(VentaReclamoDTOs ventareclamo)
        {
            try
            {
                return new JsonResult(_service.DeleteReclamo(ventareclamo)) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(VentaReclamoDTOs ventareclamo)
        {
            try
            {
                return new JsonResult(_service.UpdateVentaReclamo(ventareclamo)) { StatusCode = 200 };
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