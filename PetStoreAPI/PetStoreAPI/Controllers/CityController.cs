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
    public class CityController : Controller
    {
        private ICityRepository _city;

        public CityController(ICityRepository city)
        {
            _city = city;

        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<City>>> GetAll()
        {
            var cities = await _city.ReadAllAsync();
            return Ok(cities);
        }

        [HttpGet("one/{cityid}")]
        public async Task<ActionResult<City>> GetOne(int cityid)
        {
            var city = await _city.ReadAsync(cityid);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        [HttpPost("create")]
        public async Task<ActionResult<City>> Post(City city)
        {
            await _city.CreateAsync(city);
            return CreatedAtAction("Get", new { cityid = city.Id }, city);
        }

        [HttpPut("update")]
        public async Task<ActionResult<City>> Put(City Updated)
        {
            await _city.UpdateAsync(Updated.Id, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<City>> Remove(int cityid)
        {
            await _city.DeleteAsync(cityid);
            return NoContent();
        }

    }
}