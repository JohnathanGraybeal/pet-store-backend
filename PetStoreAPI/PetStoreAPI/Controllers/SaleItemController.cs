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
    public class SaleItemController : ControllerBase
    {
        private ISaleItemRepository _saleitem;

        public SaleItemController(ISaleItemRepository saleItem)
        {
            _saleitem = saleItem;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<SaleItem>>> GetAll()
        {
            var saleItem = await _saleitem.ReadAllAsync();
            return Ok(saleItem);
        }

        [HttpGet("one/{saleId,itemId}")]
        public async Task<ActionResult<SaleItem>> GetOne(int saleId, int itemId)
        {
            var saleItem = await _saleitem.ReadAsync(saleId, itemId);

            if (saleItem == null)
            {
                return NotFound();
            }
            return Ok(saleItem);
        }
        [HttpPost("create")]
        public async Task<ActionResult<SaleItem>> Post(SaleItem saleItem)
        {
            await _saleitem.CreateAsync(saleItem);
            return CreatedAtAction("Get", new { id = saleItem.SaleId }, saleItem);
        }

        [HttpPut("update")]
        public async Task<ActionResult<SaleItem>> Put(SaleItem Updated)
        {
            await _saleitem.UpdateAsync(Updated.SaleId, Updated.MerchandiseId, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<SaleItem>> Remove(int saleId, int itemId)
        {
            await _saleitem.DeleteAsync(saleId, itemId);
            return NoContent();
        }
    }
}