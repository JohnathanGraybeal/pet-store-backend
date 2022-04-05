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
    public class MerchandiseOrderController : Controller
    {
        private IMerchandiseOrderRepository _merchandiseOrder;

        public MerchandiseOrderController(IMerchandiseOrderRepository merchandiseOrder)
        {
            _merchandiseOrder = merchandiseOrder;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<MerchandiseOrder>>> GetAll()
        {
            var merchandiseOrder = await _merchandiseOrder.ReadAllAsync();
            return Ok(merchandiseOrder);
        }

        [HttpGet("one/{ponumber}")]
        public async Task<ActionResult<MerchandiseOrder>> GetOne(int ponumber)
        {
            var merchandiseOrder = await _merchandiseOrder.ReadAsync(ponumber);

            if (merchandiseOrder == null)
            {
                return NotFound();
            }
            return Ok(merchandiseOrder);
        }

        [HttpPost("create")]
        public async Task<ActionResult<MerchandiseOrder>> Post(MerchandiseOrder merchandiseOrder)
        {
            await _merchandiseOrder.CreateAsync(merchandiseOrder);
            return CreatedAtAction("Get", new { ponumber = merchandiseOrder.Id }, merchandiseOrder);
        }

        [HttpPut("update")]
        public async Task<ActionResult<MerchandiseOrder>> Put(MerchandiseOrder Updated)
        {
            await _merchandiseOrder.UpdateAsync(Updated.Id, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<MerchandiseOrder>> Remove(int ponumber)
        {
            await _merchandiseOrder.DeleteAsync(ponumber);
            return NoContent();
        }
    }
}
