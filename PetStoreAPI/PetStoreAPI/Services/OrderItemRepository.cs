using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private ApplicationDbContext _db;

        public OrderItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(OrderItem orderItem)
        {
            if (orderItem != null)
            {
                await _db.OrderItems.AddAsync(orderItem);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int PONumber, int itemId)
        {
            var orderItem = await ReadAsync(PONumber, itemId);

            _db.OrderItems.Remove(orderItem);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItem>> ReadAllAsync()
        {
            return await _db.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> ReadAsync(int PONumber, int itemId)
        {
            return await _db.OrderItems.FirstOrDefaultAsync(o => o.MerchandiseOrderId == PONumber && o.MerchandiseId == itemId);
        }

        public async Task UpdateAsync(int PONumber, int itemId, OrderItem orderItem)
        {

            var toUpdate = await ReadAsync(PONumber, itemId);

            if (orderItem != null)
            {
                toUpdate.Quantity = orderItem.Quantity;
                toUpdate.Cost = orderItem.Cost;

                await _db.SaveChangesAsync();
            }
        }
    }
}
