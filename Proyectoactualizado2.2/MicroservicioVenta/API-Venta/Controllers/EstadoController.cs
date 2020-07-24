using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDeAplicacion.Services;
using CapaDeDominio.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstado _service;

        public EstadoController(IEstado service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult Post(EstadoDTOs estado)
        {
            try
            {
                return new JsonResult(_service.CreateEstado(estado)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}