using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PetStoreAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Create, read and delete Users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;

        public UserController(IUserRepository user)
        {
            _user = user;
        }

        [HttpGet("one/{id}")]
        [SwaggerOperation(
    Summary = "Gets one user",
    Description = "Returns a single user",
    OperationId = "OneUser",
    Tags = new[] { "User" }
    )]
        [SwaggerResponse(200, "Returns One user", typeof(User))]
        [SwaggerResponse(404, "Specified user wasn't found", null)]
        public async Task<IActionResult> GetOne(int id)
        {
            var user = await _user.ReadAsync(id);

            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("create")]
        [Consumes(MediaTypeNames.Application.Json)]
        [SwaggerOperation(
    Summary = "Creates a user",
    Description = "Posts the user to database",
    OperationId = "CreateUser",
    Tags = new[] { "User" }
    )]
        public async Task<IActionResult> Post(User user)
        {
            await _user.CreateAsync(user);
            return CreatedAtAction("Get", new { id = user.Id, user = user.Username, password = user.Password }, user);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(
    Summary = "Deletes a user",
    Description = "Removes the user from the database",
    OperationId = "DeleteUser",
    Tags = new[] { "user" }
    )]
        [SwaggerResponse(204, "Successful specified user was deleted")]
        public async Task<IActionResult> Remove(int id)
        {
            await _user.DeleteAsync(id);
            return NoContent();
        }
    }
}
