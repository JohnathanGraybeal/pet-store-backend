using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class PreferencesRepository : IPreferencesRepository
    {
        private ApplicationDbContext _db;
        public PreferencesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Preferences preferences)
        {
            if (preferences != null)
            {
                await _db.Preferences.AddAsync(preferences);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int keyId)
        {
            var preferences = await ReadAsync(keyId);

            _db.Preferences.Remove(preferences);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Preferences>> ReadAllAsync()
        {
            return await _db.Preferences.ToListAsync();
        }

        public async Task<Preferences> ReadAsync(int keyId)
        {
            return await _db.Preferences.FirstOrDefaultAsync(p => p.KeyId == keyId);
        }

        public async Task UpdateAsync(int keyId, Preferences preferences)
        {
            var toUpdate = await ReadAsync(keyId);

            if (preferences != null)
            {
                toUpdate.Value = preferences.Value;
                toUpdate.Description = preferences.Description;


                await _db.SaveChangesAsync();
            }
        }
    }
}
