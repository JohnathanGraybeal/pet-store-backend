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
    public class SupplierController : ControllerBase
    {
        private ISupplierRepository _supplier;

        public SupplierController(ISupplierRepository supplier)
        {
            _supplier = supplier;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetAll()
        {
            var suppliers = await _supplier.ReadAllAsync();
            return Ok(suppliers);
        }

        [HttpGet("one/{id}")]
        public async Task<ActionResult<Supplier>> GetOne(int id)
        {
            var supplier = await _supplier.ReadAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }
        [HttpPost("create")]
        public async Task<ActionResult<Supplier>> Post(Supplier supplier)
        {
            await _supplier.CreateAsync(supplier);
            return CreatedAtAction("Get", new { id = supplier.Id }, supplier);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Supplier>> Put(Supplier Updated)
        {
            await _supplier.UpdateAsync(Updated.Id, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Supplier>> Remove(int id)
        {
            await _supplier.DeleteAsync(id);
            return NoContent();
        }
    }
}
