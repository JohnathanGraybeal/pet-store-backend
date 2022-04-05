using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PetStoreAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : Controller
    {
        private IOrderItemRepository _orderitem;

        public OrderItemController(IOrderItemRepository orderitem)
        {
            _orderitem = orderitem;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetAll()
        {
            var orderitems = await _orderitem.ReadAllAsync();
            return Ok(orderitems);
        }

        [HttpGet("one/{ponumber, itemid}")]
        public async Task<ActionResult<OrderItem>> GetOne(int ponumber, int itemid)
        {
            var orderitem = await _orderitem.ReadAsync(ponumber, itemid);

            if (orderitem == null)
            {
                return NotFound();
            }
            return Ok(orderitem);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OrderItem>> Post(OrderItem orderitem)
        {
            await _orderitem.CreateAsync(orderitem);
            return CreatedAtAction("Get", new { ponumber = orderitem.MerchandiseId }, orderitem);
        }

        [HttpPut("update")]
        public async Task<ActionResult<OrderItem>> Put(OrderItem Updated)
        {
            await _orderitem.UpdateAsync(Updated.MerchandiseOrderId, Updated.MerchandiseId, Updated);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<OrderItem>> Remove(int ponumber, int itemid)
        {
            await _orderitem.DeleteAsync(ponumber, itemid);
            return NoContent();
        }

    }
}
