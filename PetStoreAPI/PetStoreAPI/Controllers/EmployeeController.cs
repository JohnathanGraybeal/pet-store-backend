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
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employee;

        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var employee = await _employee.ReadAllAsync();
            return Ok(employee);
        }

        [HttpGet("one/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var employee = await _employee.ReadAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Post(Employee employee)
        {
            await _employee.CreateAsync(employee);
            return CreatedAtAction("Get", new { id = employee.Id }, employee);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put(Employee Updated)
        {
            await _employee.UpdateAsync(Updated.Id, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Remove(int id)
        {
            await _employee.DeleteAsync(id);
            return NoContent();
        }
    }
}
