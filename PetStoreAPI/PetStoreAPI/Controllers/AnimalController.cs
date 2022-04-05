using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PetStoreAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Create, read, update and delete Animals")]
    public class AnimalController : ControllerBase
    {
        private IAnimalRepository _animal;

        public AnimalController(IAnimalRepository animal)
        {
            _animal = animal;
        }

        
    [HttpGet("all")]
    [Produces(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
    Summary = "Gets all animals",
    Description = "Returns all animals in a list",
    OperationId = "AllAnimals",
    Tags = new[] { "Animal" }
    )]
        [SwaggerResponse(200, "Returns all animals", typeof(List<Animal>))]
        public async Task<ActionResult<Animal>> GetAll(int page, int limit)
        {
            var animals = await _animal.ReadAllAsync();
           
            var total = animals.Select(p => p.Id).Count();
            var pageSize = limit; // set your page size, which is number of records per page

            var currentPage = page; // set current page number, must be >= 1 (ideally this value will be passed to this logic/function from outside)

            var skip = pageSize * (currentPage - 1);

            var canPage = skip < total;

            if (!canPage) // do what you wish if you can page no further
                return null;

            var paged = animals.Skip(skip).Take(pageSize).ToList();

            return  Ok(paged);
        }

        [HttpGet("one/{id}")]
      //  [Produces(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
    Summary = "Gets one animal",
    Description = "Returns a single animal",
    OperationId = "OneAnimal",
    Tags = new[] { "Animal" }
    )]
        [SwaggerResponse(200, "Returns One animal", typeof(Animal))]
        [SwaggerResponse(404, "Specified animal wasn't found", null)]

        public async Task<ActionResult<Merchandise>> GetOne(int id)
        {
            var animal = await _animal.ReadAsync(id);

            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }
        [HttpPost("create")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
    Summary = "Creates an animal",
    Description = "Posts the animal to database",
    OperationId = "CreateAnimal",
    Tags = new[] { "Animal" }
    )]
        [SwaggerResponse(201, "Returns created at action response")]
        public async Task<ActionResult<Merchandise>> Post( Animal animal)
        {
            await _animal.CreateAsync(animal);
            return CreatedAtAction("Get", new { id = animal.Id }, animal);
        }

        [HttpPut("update")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
    Summary = "Updates an animal",
    Description = "Updates the animal with specified id if found",
    OperationId = "UpdateAnimal",
    Tags = new[] { "Animal" }
    )]
        [SwaggerResponse(204, "Successful returns no content")]
        public async Task<ActionResult<Merchandise>> Put( Animal Updated)
        {
            await _animal.UpdateAsync(Updated.Id, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        [SwaggerOperation(
    Summary = "Deletes an animal",
    Description = "Removes the animal from the database",
    OperationId = "DeleteAnimal",
    Tags = new[] { "Animal" }
    )]
        [SwaggerResponse(204, "Successful specified animal was deleted")]
        public async Task<ActionResult<Merchandise>> Remove(int id)
        {
            await _animal.DeleteAsync(id);
            return NoContent();
        }
    }
}
