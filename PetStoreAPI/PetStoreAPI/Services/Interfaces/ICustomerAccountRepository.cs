using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface ICustomerAccountRepository
    {
        Task<CustomerAccount> ReadAsync(int animalId);
        Task<IEnumerable<CustomerAccount>> ReadAllAsync();
        Task CreateAsync(CustomerAccount customerAccount);
        Task UpdateAsync(int accountId, CustomerAccount customerAccount);
        Task DeleteAsync(int accountId);
    }
}
