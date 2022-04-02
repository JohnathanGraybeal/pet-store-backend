using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class MerchandiseRepository : IMerchandiseRepository
    {
        private ApplicationDbContext _db;

        public MerchandiseRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Merchandise merchandise)
        {
            if (merchandise != null)
            {
                await _db.Merchandise.AddAsync(merchandise);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int itemId)
        {
            var merchandise = await ReadAsync(itemId);

            _db.Merchandise.Remove(merchandise);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Merchandise>> ReadAllAsync()
        {

            return  await _db.Merchandise.ToListAsync();
        }

        public async Task<Merchandise> ReadAsync(int itemId)
        {
            return await _db.Merchandise.FirstOrDefaultAsync(a => a.Id == itemId);
        }

        public async Task UpdateAsync(int itemId, Merchandise merchandise)
        {
            var toUpdate = await ReadAsync(itemId);

            if (merchandise != null)
            {
                toUpdate.Id = merchandise.Id;
                toUpdate.Description = merchandise.Description;
                toUpdate.QuantityOnHand = merchandise.QuantityOnHand;
                toUpdate.ListPrice = merchandise.ListPrice;
                toUpdate.Category = merchandise.Category;

                await _db.SaveChangesAsync();
            }
        }
    }
}
