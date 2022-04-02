using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface ISaleItemRepository
    {
        Task<SaleItem> ReadAsync(int saleId, int itemId);
        Task<IEnumerable<SaleItem>> ReadAllAsync();
        Task CreateAsync(SaleItem saleItem);
        Task UpdateAsync(int saleId, int itemId, SaleItem saleItem);
        Task DeleteAsync(int saleId, int itemId);
    }
}
