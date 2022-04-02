using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface IAnimalRepository
    {
        Task<Animal> ReadAsync(int animalId);
        Task<IEnumerable<Animal>> ReadAllAsync();
        Task CreateAsync(Animal animal);
        Task UpdateAsync(int animalId, Animal animal);
        Task DeleteAsync(int animalId);
    }
}
