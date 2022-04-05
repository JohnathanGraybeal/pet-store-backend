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
    public class SaleController : Controller
    {
        private ISaleRepository _sale;

        public SaleController(ISaleRepository sale)
        {
            _sale = sale;

        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAll()
        {
            var sales = await _sale.ReadAllAsync();
            return Ok(sales);
        }

        [HttpGet("one/{cityid}")]
        public async Task<ActionResult<Sale>> GetOne(int saleId)
        {
            var sale = await _sale.ReadAsync(saleId);

            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Sale>> Post(Sale sale)
        {
            await _sale.CreateAsync(sale);
            return CreatedAtAction("Get", new { saleId = sale.Id }, sale);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Sale>> Put(Sale Updated)
        {
            await _sale.UpdateAsync(Updated.Id, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Sale>> Remove(int saleId)
        {
            await _sale.DeleteAsync(saleId);
            return NoContent();
        }

    }
}