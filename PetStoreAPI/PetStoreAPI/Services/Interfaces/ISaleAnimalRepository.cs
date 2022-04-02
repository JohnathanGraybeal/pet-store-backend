using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface ISaleAnimalRepository
    {
        Task<SaleAnimal> ReadAsync(int saleId,int animalId);
        Task<IEnumerable<SaleAnimal>> ReadAllAsync();
        Task CreateAsync(SaleAnimal saleAnimal);
        Task UpdateAsync(int saleId, int animalId, SaleAnimal saleAnimal);
        Task DeleteAsync(int saleId, int animalId);
    }
}
