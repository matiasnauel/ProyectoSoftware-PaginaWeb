using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaAccesoDatos.Commands;
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
    public class TipoEstadoController : ControllerBase
    {
        private readonly ITipoEstadoService _service;
        public TipoEstadoController(ITipoEstadoService servicio)
        {
            _service = servicio;
        }
        [HttpPost]
        public IActionResult Post(TipoEstadoDTOs tipoestado)
        {
            try
            {
                return new JsonResult(_service.CrearTipoEstado(tipoestado)) { StatusCode = 201 };
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
                return new JsonResult(_service.GetTipoEstado()) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(TipoEstadoDTOs tipoestado)
        {
            try
            {
                return new JsonResult(_service.DeleteTipoEstado(tipoestado)) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(TipoEstadoDTOs tipoestado)
        {
            try
            {
                return new JsonResult(_service.UpdateEstado(tipoestado)) { StatusCode = 200 };
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