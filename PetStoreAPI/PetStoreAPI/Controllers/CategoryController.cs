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
    public class CategoryController : Controller
    {
        private ICategoryRepository _category;

        public CategoryController(ICategoryRepository category)
        {
            _category = category;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _category.ReadAllAsync();
            return Ok(categories);
        }

        [HttpGet("one/{id}")]
        public async Task<IActionResult> GetOne(string category)
        {
            var cat = await _category.ReadAsync(category);

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(Category category)
        {
            await _category.CreateAsync(category);
            return CreatedAtAction("Get", new { id = category.AnimalCategory }, category);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put(Category Updated)
        {
            await _category.UpdateAsync(Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Remove(string category)
        {
            await _category.DeleteAsync(category);
            return NoContent();
        }
    }
}
