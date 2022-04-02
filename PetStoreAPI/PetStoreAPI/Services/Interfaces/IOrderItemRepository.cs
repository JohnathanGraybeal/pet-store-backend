using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> ReadAsync(int PONumber, int itemId);
        Task<IEnumerable<OrderItem>> ReadAllAsync();
        Task CreateAsync(OrderItem orderItem);
        Task UpdateAsync(int PONumber, int itemId, OrderItem orderItem);
        Task DeleteAsync(int PONumber, int itemId);
    }
}
