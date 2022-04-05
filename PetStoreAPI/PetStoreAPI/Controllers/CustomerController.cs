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
    public class CustomerController : Controller
    {
        private ICustomerRepository _customer;

        public CustomerController(ICustomerRepository customer)
        {
            _customer = customer;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAll()
        {
            var customers = await _customer.ReadAllAsync();
            return Ok(customers);
        }

        [HttpGet("one/{id}")]
        public async Task<ActionResult<Customer>> GetOne(int id)
        {
            var customer = await _customer.ReadAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            await _customer.CreateAsync(customer);
            return CreatedAtAction("Get", new { id = customer.Id }, customer);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Customer>> Put(Customer Updated)
        {
            await _customer.UpdateAsync(Updated.Id, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Customer>> Remove(int id)
        {
            await _customer.DeleteAsync(id);
            return NoContent();
        }
    }
}
