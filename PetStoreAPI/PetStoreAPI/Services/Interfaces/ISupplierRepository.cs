using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface ISupplierRepository
    {
        Task<Supplier> ReadAsync(int supplierId);
        Task<IEnumerable<Supplier>> ReadAllAsync();
        Task CreateAsync(Supplier supplier);
        Task UpdateAsync(int supplierId, Supplier supplier);
        Task DeleteAsync(int supplierId);
    }
}
