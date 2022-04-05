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
    public class MerchandiseController : ControllerBase
    {
        private IMerchandiseRepository _merchandise;

        public MerchandiseController(IMerchandiseRepository merchandise)
        {
            _merchandise = merchandise;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Merchandise>>> GetAll(int page, int limit)
        {
            var merchandise = await _merchandise.ReadAllAsync();
            var total = merchandise.Select(p => p.Id).Count();
            var pageSize = limit; // set your page size, which is number of records per page

            var currentPage = page; // set current page number, must be >= 1 (ideally this value will be passed to this logic/function from outside)

            var skip = pageSize * (currentPage - 1);

            var canPage = skip < total;

            if (!canPage) // do what you wish if you can page no further
                return null;

            var paged = merchandise.Skip(skip).Take(pageSize).ToList();
            return Ok(paged);
        }

        [HttpGet("one/{id}")]
        public async Task<ActionResult<Merchandise>> GetOne(int itemId)
        {
            var merchandise = await _merchandise.ReadAsync(itemId);

            if (merchandise == null)
            {
                return NotFound();
            }
            return Ok(merchandise);
        }
        [HttpPost("create")]
        public async Task<ActionResult<Merchandise>> Post(Merchandise merchandise)
        {
            await _merchandise.CreateAsync(merchandise);
            return CreatedAtAction("Get", new { itemId = merchandise.Id }, merchandise);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Merchandise>> Put(Merchandise Updated)
        {
            await _merchandise.UpdateAsync(Updated.Id, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Merchandise>> Remove(int itemId)
        {
            await _merchandise.DeleteAsync(itemId);
            return NoContent();
        }
    }
}
