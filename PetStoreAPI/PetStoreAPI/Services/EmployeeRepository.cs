using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Employee employee)
        {
            if (employee != null)
            {
                await _db.Employees.AddAsync(employee);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employees = await ReadAsync(employeeId);

            _db.Employees.Remove(employees);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> ReadAllAsync()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<Employee> ReadAsync(int employeeId)
        {
            return await _db.Employees.FirstOrDefaultAsync(a => a.Id == employeeId);
        }

        public async Task UpdateAsync(int employeeId, Employee employee)
        {
            var toUpdate = await ReadAsync(employeeId);

            if (employee != null)
            {
                toUpdate.LastName = employee.LastName;
                toUpdate.FirstName = employee.FirstName;
                toUpdate.Phone = employee.Phone;
                toUpdate.Address = employee.Address;
                toUpdate.ZipCode = employee.ZipCode;
                toUpdate.DateHired = employee.DateHired;
                toUpdate.DateReleased = employee.DateReleased;
                toUpdate.EmployeeLevel = employee.EmployeeLevel;
                toUpdate.Title = employee.Title;
                toUpdate.TaxPayerId = employee.TaxPayerId;
                toUpdate.ManagerId = employee.ManagerId;
                toUpdate.CityId = employee.CityId;


                await _db.SaveChangesAsync();
            }
        }
    }
}
