using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaIFX.Modelos;
using PruebaIFX.Persistencia.IRepositorio;

namespace PruebaIFX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosRepositorio EmpleadosRepositorio;
        public EmpleadosController(IEmpleadosRepositorio empleadosRepositorio)
        {
            EmpleadosRepositorio = empleadosRepositorio;
        }
        [HttpPost]
        [Route("GetObjEmpleado")]
        public IActionResult GetObjEmpleado([FromBody] EmpleadosModel entidad)
        {
            return Ok(EmpleadosRepositorio.GetObjEmpleado(entidad));
        }
        [HttpGet]
        [Route("GetEmpleados")]
        public IActionResult GetEmpleados()
        {
            return Ok(EmpleadosRepositorio.GetEmpleados());
        }
        [HttpPost]
        [Route("CreateEmpleado")]
        public IActionResult CreateEmpleado([FromBody] EmpleadosModel entidad)
        {
            return Ok(EmpleadosRepositorio.CreateEmpleado(entidad));
        }
        [HttpPut]
        [Route("UpdateEmpleado")]
        public IActionResult UpdateEmpleado([FromBody] EmpleadosModel entidad)
        {
            return Ok(EmpleadosRepositorio.UpdateEmpleado(entidad));
        }
    }
}
