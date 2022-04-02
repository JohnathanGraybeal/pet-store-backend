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
    public class AnimalOrderController : ControllerBase
    {
        private IAnimalOrderRepository _animalOrder;

        public AnimalOrderController(IAnimalOrderRepository animalOrder)
        {
            _animalOrder = animalOrder;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var animalOrders = await _animalOrder.ReadAllAsync();
            return Ok(animalOrders);
        }

        [HttpGet("one/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var animalOrder = await _animalOrder.ReadAsync(id);

            if (animalOrder == null)
            {
                return NotFound();
            }
            return Ok(animalOrder);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody]AnimalOrder animalOrder)
        {
            await _animalOrder.CreateAsync(animalOrder);
            return CreatedAtAction("Get", new { orderId = animalOrder.Id }, animalOrder);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put(AnimalOrder Updated)
        {
            await _animalOrder.UpdateAsync(Updated.Id, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Remove(int id)
        {
            await _animalOrder.DeleteAsync(id);
            return NoContent();
        }
    }
}
