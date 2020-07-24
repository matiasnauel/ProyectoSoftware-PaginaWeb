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
    public class FormaPagoController : ControllerBase
    {
        private readonly IFormaPagoService _service;
        public FormaPagoController(IFormaPagoService servicio)
        {
            _service = servicio;
        }
        [HttpPost]
        public IActionResult Post(FormaPagoDTOs formapago)
        {
            try
            {
                return new JsonResult(_service.CreatePagos(formapago)) { StatusCode = 201 };
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
                return new JsonResult(_service.GetFormaPago()) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(FormaPagoDTOs forma)
        {
            try
            {
                return new JsonResult(_service.DeleteFormPago(forma)) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(FormaPagoDTOs forma)
        {
            try
            {
                return new JsonResult(_service.UpdateFormaPago(forma)) { StatusCode = 200 };
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