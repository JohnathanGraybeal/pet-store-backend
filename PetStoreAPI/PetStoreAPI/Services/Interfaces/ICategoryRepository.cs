using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> ReadAsync(string category);
        Task<IEnumerable<Category>> ReadAllAsync();
        Task CreateAsync(Category animal);
        Task UpdateAsync( Category cat);
        Task DeleteAsync(string category);
    }
}
