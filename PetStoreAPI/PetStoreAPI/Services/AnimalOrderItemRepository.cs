using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class AnimalOrderItemRepository : IAnimalOrderItemRepository
    {
        private ApplicationDbContext _db;

        public AnimalOrderItemRepository(ApplicationDbContext db )
        {
            _db = db;
        }
        public async Task CreateAsync(AnimalOrderItem animalOrderItem)
        {
            if (animalOrderItem != null)
            {
                await _db.AnimalOrderItems.AddAsync(animalOrderItem);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int orderId, int animalId)
        {
            var animalOrderItem = await ReadAsync(orderId, animalId);

            _db.AnimalOrderItems.Remove(animalOrderItem);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<AnimalOrderItem>> ReadAllAsync()
        {
            return await _db.AnimalOrderItems.ToListAsync();
        }

        public async Task<AnimalOrderItem> ReadAsync(int orderId, int animalId)
        {
            return await _db.AnimalOrderItems.FirstOrDefaultAsync(a => a.AnimalOrderId == orderId && a.AnimalId == animalId);
        }

        public async Task UpdateAsync(int orderId, int animalId, AnimalOrderItem animalOrderItem)
        {
            var toUpdate = await ReadAsync(orderId, animalId);

            if (toUpdate != null)
            {
                toUpdate.Cost = animalOrderItem.Cost;


                await _db.SaveChangesAsync();
            }
        }
    }
}
