using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblioteka.BibliotekaModel;
using Biblioteka.Interfaces;

namespace Biblioteka
{
   
    public class MemberRepository : IMemberRepository
    {
        LibraryContext dbContext = new LibraryContext();
        public MemberRepository()
        {
        }

        public async Task<List<Member>> GetAll()
        {
            return await dbContext.Members.ToListAsync();
        }
        public async Task<Member?> GetById(int id)
        {
            return await dbContext.Members.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Member member)
        {
            bool rv = false;
            var findMember = await dbContext.Members.FirstOrDefaultAsync(x => x.Id == member.Id);
            if (findMember == null)
                return false;
            findMember.Ime = member.Ime;
            findMember.Prezime = member.Prezime;
            findMember.TelefonskiBroj = member.TelefonskiBroj;
            return (await dbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var entityToRemove = await dbContext.Members.FirstOrDefaultAsync(x => x.Id == id);
            if (entityToRemove == null) return false;
            dbContext.Remove(entityToRemove);
            return (await dbContext.SaveChangesAsync() > 0);
        }

        public async Task<int> Create(Member member)
        {
            await dbContext.Members.AddAsync(member);
            await dbContext.SaveChangesAsync();
            return member.Id;
        }
    }

   
}

