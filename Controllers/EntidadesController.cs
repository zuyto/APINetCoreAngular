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
    public class EntidadesController : ControllerBase
    {
        private readonly IEntidadesRepositorio EntidadesRepositorio;
        public EntidadesController(IEntidadesRepositorio entidadesRepositorio)
        {
            EntidadesRepositorio = entidadesRepositorio;
        }
        [HttpPost]
        [Route("GetObjEntidad")]
        public IActionResult GetObjEntidad([FromBody] EntidadesModel entidad)
        {
            return Ok(EntidadesRepositorio.GetObjEntidad(entidad));
        }
        [HttpGet]
        [Route("GetEntidades")]
        public IActionResult GetEntidades()
        {
            return Ok(EntidadesRepositorio.GetEntidades());
        }
        [HttpPost]
        [Route("CreateEntidad")]
        public IActionResult CreateEntidad([FromBody] EntidadesModel entidad)
        {
            return Ok(EntidadesRepositorio.CreateEntidad(entidad));
        }
        [HttpPut]
        [Route("UpdateEntidad")]
        public IActionResult UpdateEntidad([FromBody] EntidadesModel entidad)
        {
            return Ok(EntidadesRepositorio.UpdateEntidad(entidad));
        }
    }
}
