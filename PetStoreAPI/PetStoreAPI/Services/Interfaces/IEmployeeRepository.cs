using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> ReadAsync(int employeeId);
        Task<IEnumerable<Employee>> ReadAllAsync();
        Task CreateAsync(Employee employee);
        Task UpdateAsync(int employeeId, Employee employee);
        Task DeleteAsync(int employeeId);
    }
}
