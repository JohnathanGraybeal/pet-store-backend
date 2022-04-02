using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class RevisionRepository : IRevisionRepository
    {
        private ApplicationDbContext _db;
        public RevisionRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Revision revision)
        {
            if (revision != null)
            {
                await _db.Revisions.AddAsync(revision);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int revisionId)
        {
            var revision = await ReadAsync(revisionId);

            _db.Revisions.Remove(revision);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Revision>> ReadAllAsync()
        {
            return await _db.Revisions.ToListAsync();
        }

        public async Task<Revision> ReadAsync(int revisionId)
        {
            return await _db.Revisions.FirstOrDefaultAsync(a => a.Id == revisionId);
        }

        public async Task UpdateAsync(int revisionId, Revision revision)
        {
            var toUpdate = await ReadAsync(revisionId);

            if (revision != null)
            {
                toUpdate.Version = revision.Version;
                toUpdate.Description = revision.Description;
                toUpdate.Author = revision.Author;
                toUpdate.ReleaseDate = revision.ReleaseDate;


                await _db.SaveChangesAsync();
            }
        }
    }
}
