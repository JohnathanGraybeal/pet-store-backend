using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface IRevisionRepository
    {
        Task<Revision> ReadAsync(int revisionId);
        Task<IEnumerable<Revision>> ReadAllAsync();
        Task CreateAsync(Revision revision);
        Task UpdateAsync(int revisionId, Revision revision);
        Task DeleteAsync(int revisionId);
    }
}
