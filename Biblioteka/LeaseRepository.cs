using Biblioteka.BibliotekaModel;
using Biblioteka.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
   
    public class LeaseRepository : ILeaseRepository
    {
        LibraryContext dbContext = new LibraryContext();
        public LeaseRepository()
        {
        }

        public async Task<List<Lease>> GetAll()
        {
            return await dbContext.Leases.ToListAsync();
        }
        public async Task<Lease?> GetById(int id)
        {
            return await dbContext.Leases.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Lease lease)
        {
            bool rv = false;
            var findLease = await dbContext.Leases.FirstOrDefaultAsync(x => x.Id == lease.Id);
            if (findLease == null)
                return false;
            findLease.DateLeased = lease.DateLeased;
            findLease.DateReturned = lease.DateReturned;
            findLease.MemberId = lease.MemberId;
            findLease.BookId = lease.BookId;
            return (await dbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var entityToRemove = await dbContext.Leases.FirstOrDefaultAsync(x => x.Id == id);
            if (entityToRemove == null) return false;
            dbContext.Remove(entityToRemove);
            return (await dbContext.SaveChangesAsync() > 0);
        }

        public async Task<int> Create(Lease lease)
        {
            await dbContext.Leases.AddAsync(lease);
            await dbContext.SaveChangesAsync();
            return lease.Id;
        }
    }

    
}

