using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class SaleRepository : ISaleRepository
    {
        private ApplicationDbContext _db;
        public SaleRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Sale sale)
        {
            if (sale != null)
            {
                await _db.Sales.AddAsync(sale);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int saleId)
        {
            var sale = await ReadAsync(saleId);

            _db.Sales.Remove(sale);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sale>> ReadAllAsync()
        {
            return await _db.Sales.ToListAsync();
        }

        public async Task<Sale> ReadAsync(int saleId)
        {
            return await _db.Sales.FirstOrDefaultAsync(a => a.Id == saleId);
        }

        public async Task UpdateAsync(int saleId, Sale sale)
        {
            var toUpdate = await ReadAsync(saleId);

            if (sale != null)
            {
                toUpdate.SaleDate = sale.SaleDate;
                toUpdate.SalesTax = sale.SalesTax;
                toUpdate.EmployeeId = sale.EmployeeId;
                toUpdate.CustomerId = sale.CustomerId;


                await _db.SaveChangesAsync();
            }
        }
    }
}
