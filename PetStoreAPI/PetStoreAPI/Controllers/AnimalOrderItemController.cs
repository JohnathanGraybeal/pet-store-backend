using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PetStoreAPI.Models.Entities;
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
    public class AnimalOrderItemController : Controller
    {
        private IAnimalOrderItemRepository _animalorderitem;

        public AnimalOrderItemController(IAnimalOrderItemRepository animalOrderItem)
        {
            _animalorderitem = animalOrderItem;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<AnimalOrderItem>>> GetAll()
        {
            var animalOrderItems = await _animalorderitem.ReadAllAsync();
            return Ok(animalOrderItems);
        }

        [HttpGet("one/{orderid,animalid}")]
        public async Task<ActionResult<AnimalOrderItem>> GetOne(int orderid, int animalid)
        {
            var animalOrderItem = await _animalorderitem.ReadAsync(orderid, animalid);

            if (animalOrderItem == null)
            {
                return NotFound();
            }
            return Ok(animalOrderItem);
        }

        [HttpPost("create")]
        public async Task<ActionResult<AnimalOrderItem>> Post(AnimalOrderItem animalOrderItem)
        {
            await _animalorderitem.CreateAsync(animalOrderItem);
            return CreatedAtAction("Get", new { orderid = animalOrderItem.AnimalOrderId, animalId = animalOrderItem.AnimalId }, animalOrderItem);
        }

        [HttpPut("update")]
        public async Task<ActionResult<AnimalOrderItem>> Put(AnimalOrderItem Updated)
        {
            await _animalorderitem.UpdateAsync(Updated.AnimalOrderId, Updated.AnimalId, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<AnimalOrderItem>> Remove(int orderid, int animalid)
        {
            await _animalorderitem.DeleteAsync(orderid, animalid);
            return NoContent();
        }
    }
}
