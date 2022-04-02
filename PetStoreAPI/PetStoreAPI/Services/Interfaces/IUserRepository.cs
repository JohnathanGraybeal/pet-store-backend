using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<User> ReadAsync(int userId); 
        Task CreateAsync(User user);
        Task DeleteAsync(int userId);
    }
}
