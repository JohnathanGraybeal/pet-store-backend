using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleAnimalController : Controller
    {
        private ISaleAnimalRepository _saleanimal;

        public SaleAnimalController(ISaleAnimalRepository saleAnimal)
        {
            _saleanimal = saleAnimal;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<SaleAnimal>>> GetAll()
        {
            var saleAnimal = await _saleanimal.ReadAllAsync();
            return Ok(saleAnimal);
        }

        [HttpGet("one/{saleid,animalid}")]
        public async Task<ActionResult<SaleAnimal>> GetOne(int saleId, int animalId)
        {
            var saleAnimal = await _saleanimal.ReadAsync(saleId, animalId);

            if (saleAnimal == null)
            {
                return NotFound();
            }
            return Ok(saleAnimal);
        }

        [HttpPost("create")]
        public async Task<ActionResult<SaleAnimal>> Post(SaleAnimal saleAnimal)
        {
            await _saleanimal.CreateAsync(saleAnimal);
            return CreatedAtAction("Get", new { saleid = saleAnimal.SaleId, animalid = saleAnimal.AnimalId }, saleAnimal);
        }

        [HttpPut("update")]
        public async Task<ActionResult<SaleAnimal>> Put(SaleAnimal Updated)
        {
            await _saleanimal.UpdateAsync(Updated.SaleId, Updated.AnimalId, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<SaleAnimal>> Remove(int saleId, int animalId)
        {
            await _saleanimal.DeleteAsync(saleId, animalId);
            return NoContent();
        }
    }
}