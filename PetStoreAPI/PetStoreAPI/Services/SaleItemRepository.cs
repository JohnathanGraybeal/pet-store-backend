using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class SaleItemRepository : ISaleItemRepository
    {
        private ApplicationDbContext _db;
        public SaleItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(SaleItem saleItem)
        {
            if (saleItem != null)
            {
                await _db.SaleItems.AddAsync(saleItem);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int saleId, int itemId)
        {
            var saleItem = await ReadAsync(saleId, itemId);

            _db.SaleItems.Remove(saleItem);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<SaleItem>> ReadAllAsync()
        {
            return await _db.SaleItems.ToListAsync(); ;
        }

        public async Task<SaleItem> ReadAsync(int saleId, int itemId)
        {
            return await _db.SaleItems.FirstOrDefaultAsync(a => a.SaleId == saleId && a.MerchandiseId == itemId);
        }

        public async Task UpdateAsync(int saleId, int itemId, SaleItem saleItem)
        {
            var toUpdate = await ReadAsync(saleId, itemId);

            if (saleItem != null)
            {
                toUpdate.Quantity = saleItem.Quantity;
                toUpdate.SalePrice = saleItem.SalePrice;

                await _db.SaveChangesAsync();
            }
        }
    }
}
