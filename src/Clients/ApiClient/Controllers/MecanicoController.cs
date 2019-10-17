using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Transactions;
using Models.Dto;
using Services.Interfaces;

namespace ApiClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicoController : ControllerBase
    {
        private readonly IMecanicoService _mecanicoService;

        public MecanicoController(
            IMecanicoService mecanicoService
            )
        {
            _mecanicoService = mecanicoService;
        }

        
        [HttpGet("prueba")]
        public IActionResult Prueba()
        {
            return Ok("Exitoso");
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mecanicoService.GetAll());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] MecanicoDto model)
        {
            _mecanicoService.Create(model);
            return NoContent();
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] MecanicoDto model)
        {
            _mecanicoService.Update(model);
            return NoContent();
        }
        
        [HttpDelete]
        public IActionResult Delete([FromBody] MecanicoDto model)
        {
            _mecanicoService.Remove(model);
            return NoContent();
        }
    }
}
