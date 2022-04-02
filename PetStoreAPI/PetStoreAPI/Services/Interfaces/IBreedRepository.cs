using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface IBreedRepository
    {
        Task<Breed> ReadAsync(Breed breed);
        Task<IEnumerable<Breed>> ReadAllAsync();
        Task CreateAsync(Breed breed);
        Task UpdateAsync( Breed breed );
        Task DeleteAsync(Breed breed);
    }
}
