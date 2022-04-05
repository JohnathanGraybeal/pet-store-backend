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
    public class PreferencesController : Controller
    {
        private IPreferencesRepository _preferences;

        public PreferencesController(IPreferencesRepository preferences)
        {
            _preferences = preferences;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Preferences>>> GetAll()
        {
            var preferencess = await _preferences.ReadAllAsync();
            return Ok(preferencess);
        }

        [HttpGet("one/{keyid}")]
        public async Task<ActionResult<Preferences>> GetOne(int keyid)
        {
            var preferences = await _preferences.ReadAsync(keyid);

            if (preferences == null)
            {
                return NotFound();
            }
            return Ok(preferences);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Preferences>> Post(Preferences preferences)
        {
            await _preferences.CreateAsync(preferences);
            return CreatedAtAction("Get", new { keyid = preferences.KeyId }, preferences);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Preferences>> Put(Preferences Updated)
        {
            await _preferences.UpdateAsync(Updated.KeyId, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Preferences>> Remove(int keyid)
        {
            await _preferences.DeleteAsync(keyid);
            return NoContent();
        }
    }
}
