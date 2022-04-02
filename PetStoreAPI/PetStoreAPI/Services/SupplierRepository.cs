using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class SupplierRepository : ISupplierRepository
    {
        private ApplicationDbContext _db;
        public SupplierRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Supplier supplier)
        {
            if (supplier != null)
            {
                await _db.Suppliers.AddAsync(supplier);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int supplierId)
        {
            var supplier = await ReadAsync(supplierId);

            _db.Suppliers.Remove(supplier);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Supplier>> ReadAllAsync()
        {
            return await _db.Suppliers.ToListAsync();
        }

        public async Task<Supplier> ReadAsync(int supplierId)
        {
            return await _db.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierId);
        }

        public async Task UpdateAsync(int supplierId, Supplier supplier)
        {
            var toUpdate = await ReadAsync(supplierId);

            if(supplier != null)
            {
                toUpdate.Name = supplier.Name;
                toUpdate.ContactName = supplier.ContactName;
                toUpdate.Phone = supplier.Phone;
                toUpdate.Address = supplier.Address;
                toUpdate.ZipCode = supplier.ZipCode;
                toUpdate.CityId = supplier.CityId;
            }
        }
    }
}
