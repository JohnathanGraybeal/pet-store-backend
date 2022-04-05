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
    public class RevisionController : ControllerBase
    {
        private IRevisionRepository _revision;

        public RevisionController(IRevisionRepository revision)
        {
            _revision = revision;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Revision>>> GetAll()
        {
            var revision = await _revision.ReadAllAsync();
            return Ok(revision);
        }

        [HttpGet("one/{saleId,itemId}")]
        public async Task<ActionResult<Revision>> GetOne(int Id)
        {
            var revision = await _revision.ReadAsync(Id);

            if (revision == null)
            {
                return NotFound();
            }
            return Ok(revision);
        }
        [HttpPost("create")]
        public async Task<ActionResult<Revision>> Post(Revision revision)
        {
            await _revision.CreateAsync(revision);
            return CreatedAtAction("Get", new { id = revision.Id }, revision);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Revision>> Put(Revision Updated)
        {
            await _revision.UpdateAsync(Updated.Id, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Revision>> Remove(int Id)
        {
            await _revision.DeleteAsync(Id);
            return NoContent();
        }
    }
}
