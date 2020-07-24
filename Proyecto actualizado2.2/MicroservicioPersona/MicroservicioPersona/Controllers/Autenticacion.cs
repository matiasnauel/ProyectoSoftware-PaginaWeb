using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APLICACION.SERVICES;
using DOMINIO.DTOS;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NPOI.Util;
using RestSharp;

namespace MicroservicioPersona.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Autenticacion : ControllerBase
    {
        private readonly IAutenticacionServices _service;


        string uid = "UKCXMI2Fo1S1NhYBNTxFKWLp6RC3";
        string cadena = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjZjZmMyMzViZDYxMGZhY2FlYzVlYjBhZGU5NTg5ZGE5NTI4MmRlY2QiLCJ0eXAiOiJKV1QifQ.eyJuYW1lIjoiTWF0aWFzIEF5YWxhIiwicGljdHVyZSI6Imh0dHBzOi8vbGgzLmdvb2dsZXVzZXJjb250ZW50LmNvbS9hLS9BT2gxNEdnNmxEaEhGOS1abndKbEdQTk4yZ24wYW0tVTVlU2NwZWliamJaRyIsImlzcyI6Imh0dHBzOi8vc2VjdXJldG9rZW4uZ29vZ2xlLmNvbS91c3VhcmlvLTUwOTNlIiwiYXVkIjoidXN1YXJpby01MDkzZSIsImF1dGhfdGltZSI6MTU5NTM1NjA5NywidXNlcl9pZCI6IlVLQ1hNSTJGbzFTMU5oWUJOVHhGS1dMcDZSQzMiLCJzdWIiOiJVS0NYTUkyRm8xUzFOaFlCTlR4RktXTHA2UkMzIiwiaWF0IjoxNTk1MzYwNDU1LCJleHAiOjE1OTUzNjQwNTUsImVtYWlsIjoiYXlhbGEubWF0aWFzLm1hQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJmaXJlYmFzZSI6eyJpZGVudGl0aWVzIjp7Imdvb2dsZS5jb20iOlsiMTE0NDgyMzc3ODUwMzM1Mzg4OTg4Il0sImVtYWlsIjpbImF5YWxhLm1hdGlhcy5tYUBnbWFpbC5jb20iXX0sInNpZ25faW5fcHJvdmlkZXIiOiJnb29nbGUuY29tIn19.OlqFYrnNRr6VQhH75Nmw-7Bh8X7YN6-YIA8QHCw8MYg8IMiCRtssicUcJMz1nfUgZb8xU2z36Zh29NgcbaW8onHk6Xj5EdrSIyPGZHanJ1dRAfdt7TEc0SKVJlD_jlcZkrjCxCJMIAFclInviLdOMypzf5kGmlNQJPNyHSmqGGRfwYhM0WgpMHqqHMEi1Bv5lKkjDGaKV1_Ckzlt0Z19-nHzftErD0KLvfBTPAzafVlXizsqh2c9eOmuGQlCTThsOHVM52TVmpOGX84mSwptPhshBEKm9jx6H9ki6SiUj5CZnwmJZ7YX47UHUMM0y4yxVEh917JyKGofm01V-WLy4g";

        public Autenticacion(IAutenticacionServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(@"D:\Datos Matias\firebase\Private Key\usuario-5093e-firebase-adminsdk-43fcf-1bf89503c6.json"),
            });
            FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(cadena);
            string uid = decodedToken.Uid;
            return uid;

        }
        //---------------  getUserDate".-devolver datos del usuario.- --------------------------------------------//
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserDate() {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(@"D:\Datos Matias\firebase\Private Key\usuario-5093e-firebase-adminsdk-43fcf-1bf89503c6.json"),
            });
            var result = await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
            return new JsonResult(result) { StatusCode = 201 };

        }
        //----------------validar con token de usuario-----------------------------//
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult getCliente([FromQuery] string uids )
        {
            try
            {
               
                return new JsonResult(_service.getCarrito(uids).Result) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

        [HttpGet("[action]")]
        public IActionResult getClienteCarrito([FromQuery]int clienteCarrito)
        {


            return new JsonResult(_service.Get(clienteCarrito).Result) ;
            
         
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ValidarCliente([FromQuery] string uids)
        {
          
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(@"D:\Datos Matias\firebase\Private Key\usuario-5093e-firebase-adminsdk-43fcf-1bf89503c6.json"),
            });

            var result = await FirebaseAuth.DefaultInstance.GetUserAsync(uids);
           
            return new JsonResult(result) { StatusCode = 201 };
        }


    }
}









