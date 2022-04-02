using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
        public interface ICustomerRepository
        {
            Task<Customer> ReadAsync(int customerId);
            Task<IEnumerable<Customer>> ReadAllAsync();
            Task CreateAsync(Customer customer);
            Task UpdateAsync(int customerId, Customer customer);
            Task DeleteAsync(int customerId);
        }
    
}
