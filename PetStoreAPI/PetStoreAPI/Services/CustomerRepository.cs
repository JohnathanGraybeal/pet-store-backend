using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Customer customer)
        {
            if (customer != null)
            {
                await _db.Customers.AddAsync(customer);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int customerId)
        {
            var customer = await ReadAsync(customerId);

            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> ReadAllAsync()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Customer> ReadAsync(int customerId)
        {
            return await _db.Customers.FirstOrDefaultAsync(a => a.Id == customerId);
        }

        public async Task UpdateAsync(int customerId, Customer customer)
        {
            var toUpdate = await ReadAsync(customerId);

            if (customer != null)
            {
                toUpdate.Phone = customer.Phone;
                toUpdate.FirstName = customer.FirstName;
                toUpdate.LastName = customer.LastName;
                toUpdate.Address = customer.Address;
                toUpdate.ZipCode = customer.ZipCode;
                toUpdate.CityId = customer.CityId;


                await _db.SaveChangesAsync();
            }
        }
    }
}
