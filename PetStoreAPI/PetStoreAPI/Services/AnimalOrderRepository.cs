using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class AnimalOrderRepository : IAnimalOrderRepository
    {
        private ApplicationDbContext _db;

        public AnimalOrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(AnimalOrder animalOrder)
        {
            if (animalOrder != null)
            {
                await _db.AnimalOrders.AddAsync(animalOrder);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int animalOrderId)
        {
            var animalOrder = await ReadAsync(animalOrderId);

            _db.AnimalOrders.Remove(animalOrder);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<AnimalOrder>> ReadAllAsync()
        {
            return await _db.AnimalOrders.ToListAsync();
        }

        public async Task<AnimalOrder> ReadAsync(int animalOrderId)
        {
            return await _db.AnimalOrders.FirstOrDefaultAsync(a => a.Id == animalOrderId);
        }

        public async Task UpdateAsync(int animalOrderId, AnimalOrder animalOrder)
        {
            var toUpdate = await ReadAsync(animalOrderId);

            if (animalOrder != null)
            {
                toUpdate.Id = animalOrder.Id;
                toUpdate.OrderDate = animalOrder.OrderDate;
                toUpdate.RecievedDate = animalOrder.RecievedDate;
                toUpdate.ShippingCost = animalOrder.ShippingCost;
                toUpdate.Supplier = animalOrder.Supplier;
                toUpdate.EmployeeId = animalOrder.EmployeeId;

                await _db.SaveChangesAsync();
            }
        }
    }
}
