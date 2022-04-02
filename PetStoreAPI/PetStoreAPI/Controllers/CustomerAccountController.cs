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
    public class CustomerAccountController : ControllerBase
    {
        private ICustomerAccountRepository _customerAccount;

        public CustomerAccountController(ICustomerAccountRepository customerAccount)
        {
            _customerAccount = customerAccount;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var customerAccount = await _customerAccount.ReadAllAsync();
            return Ok(customerAccount);
        }

        [HttpGet("one/{id}")]
        public async Task<IActionResult> GetOne(int accountId)
        {
            var customerAccount = await _customerAccount.ReadAsync(accountId);

            if (customerAccount == null)
            {
                return NotFound();
            }
            return Ok(customerAccount);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Post(CustomerAccount customerAccount)
        {
            await _customerAccount.CreateAsync(customerAccount);
            return CreatedAtAction("Get", new { id = customerAccount.Id }, customerAccount);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put(CustomerAccount Updated)
        {
            await _customerAccount.UpdateAsync(Updated.Id, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Remove(int AccountId)
        {
            await _customerAccount.DeleteAsync(AccountId);
            return NoContent();
        }
    }
}
