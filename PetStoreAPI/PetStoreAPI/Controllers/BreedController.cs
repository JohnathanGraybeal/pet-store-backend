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
    public class BreedController : ControllerBase
    {
        private IBreedRepository _animalBreed;

        public BreedController(IBreedRepository breed)
        {
            _animalBreed = breed;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Breed>>> GetAll()
        {
            var breeds = await _animalBreed.ReadAllAsync();
            return Ok(breeds);
        }

        [HttpGet("one/{id}")]
        public async Task<ActionResult<Breed>> GetOne(Breed breed)
        {
            var breeds = await _animalBreed.ReadAsync(breed);

            if (breeds == null)
            {
                return NotFound();
            }
            return Ok(breeds);
        }
        [HttpPost("create")]
        public async Task<ActionResult<Breed>> Post(Breed breed)
        {
            await _animalBreed.CreateAsync(breed);
            return CreatedAtAction("Get", new { category = breed.Category, animalBreed = breed.AnimalBreed }, breed);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Breed>> Put(Breed Updated)
        {
            await _animalBreed.UpdateAsync(Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Breed>> Remove(Breed breed)
        {
            await _animalBreed.DeleteAsync(breed);
            return NoContent();
        }
    }
}
