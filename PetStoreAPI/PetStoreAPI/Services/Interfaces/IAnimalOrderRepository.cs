using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface IAnimalOrderRepository
    {
        Task<AnimalOrder> ReadAsync(int animalOrderId);
        Task<IEnumerable<AnimalOrder>> ReadAllAsync();
        Task CreateAsync(AnimalOrder animalOrder);
        Task UpdateAsync(int animalOrderId, AnimalOrder animalOrder);
        Task DeleteAsync(int animalOrderId);
    }
}
