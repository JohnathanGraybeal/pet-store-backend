using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class AnimalRepository : IAnimalRepository
    {
        private ApplicationDbContext _db;

        public AnimalRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Animal animal)
        {
            if (animal != null)
            {
                await _db.Animals.AddAsync(animal);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int animalId)
        {
            var animal = await ReadAsync(animalId);

            _db.Animals.Remove(animal);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Animal>> ReadAllAsync()
        {
            return await _db.Animals.ToListAsync();
        }

        public async Task<Animal> ReadAsync(int animalId)
        {
            return await _db.Animals.FirstOrDefaultAsync(a => a.Id == animalId);
        }

        public async Task UpdateAsync(int animalId, Animal animal)
        {
            var toUpdate = await ReadAsync(animalId);

            if(animal != null)
            {
                toUpdate.Breed = animal.Breed;
               // toUpdate.Category = animal.Category;
                toUpdate.Color = animal.Color;
                toUpdate.DateBorn = animal.DateBorn;
                toUpdate.Gender = animal.Gender;
                toUpdate.ImageFile = animal.ImageFile;
                toUpdate.ImageHeight = animal.ImageHeight;
                toUpdate.ImageWidth = animal.ImageWidth;
                toUpdate.ListPrice = animal.ListPrice;
                toUpdate.Photo = animal.Photo;
                toUpdate.Registered = animal.Registered;
                toUpdate.Name = animal.Name;


                await _db.SaveChangesAsync();
            }
        }
    }
}
