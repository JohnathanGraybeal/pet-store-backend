using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface IAnimalOrderItemRepository
    {
        Task<AnimalOrderItem> ReadAsync(int orderId, int AnimalId);
        Task<IEnumerable<AnimalOrderItem>> ReadAllAsync();
        Task CreateAsync(AnimalOrderItem animalOrderItem);
        Task UpdateAsync(int orderId, int animalId, AnimalOrderItem animalOrderItem);
        Task DeleteAsync(int orderId, int animalId);
    }
}
