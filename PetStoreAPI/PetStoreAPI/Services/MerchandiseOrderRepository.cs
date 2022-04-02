using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class MerchandiseOrderRepository : IMerchandiseOrderRepository
    {
        private ApplicationDbContext _db;
        public MerchandiseOrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(MerchandiseOrder merchandiseOrder)
        {
            if (merchandiseOrder != null)
            {
                await _db.MerchandiseOrders.AddAsync(merchandiseOrder);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int PONumber)
        {
            var merchandiseOrder = await ReadAsync(PONumber);

            _db.MerchandiseOrders.Remove(merchandiseOrder);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<MerchandiseOrder>> ReadAllAsync()
        {
            return await _db.MerchandiseOrders.ToListAsync();
        }

        public async Task<MerchandiseOrder> ReadAsync(int PONumber)
        {
            return await _db.MerchandiseOrders.FirstOrDefaultAsync(a => a.Id == PONumber);
        }

        public async Task UpdateAsync(int PONumber, MerchandiseOrder merchandiseOrder)
        {
            var toUpdate = await ReadAsync(PONumber);

            if (merchandiseOrder != null)
            {
                toUpdate.OrderDate = merchandiseOrder.OrderDate;
                toUpdate.RecievedDate = merchandiseOrder.RecievedDate;
                toUpdate.SupplierId = merchandiseOrder.SupplierId;
                toUpdate.EmployeeId = merchandiseOrder.EmployeeId;
                toUpdate.ShippingCost = merchandiseOrder.ShippingCost; ;

                await _db.SaveChangesAsync();
            }
        }
    }
}
