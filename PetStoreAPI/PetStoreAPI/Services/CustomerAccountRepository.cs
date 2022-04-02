using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class CustomerAccountRepository : ICustomerAccountRepository
    {
        private ApplicationDbContext _db;
        public CustomerAccountRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(CustomerAccount customerAccount)
        {
            if (customerAccount != null)
            {
                await _db.CustomerAccounts.AddAsync(customerAccount);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int accountId)
        {
            var customerAccount = await ReadAsync(accountId);

            _db.CustomerAccounts.Remove(customerAccount);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerAccount>> ReadAllAsync()
        {
            return await _db.CustomerAccounts.ToListAsync();
        }

        public async Task<CustomerAccount> ReadAsync(int accountId)
        {
            return await _db.CustomerAccounts.FirstOrDefaultAsync(a => a.Id == accountId);
        }

        public async Task UpdateAsync(int accountId, CustomerAccount customerAccount)
        {
             var toUpdate = await ReadAsync(accountId);

            if (customerAccount != null)
            {
                toUpdate.Id = customerAccount.Id;
                toUpdate.Balance = customerAccount.Balance;
                toUpdate.CustomerId = customerAccount.CustomerId;
                
                await _db.SaveChangesAsync();
            }
        }
    }
}
