using Biblioteka.BibliotekaModel;
using Biblioteka.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka
{
    
    public class AuthorRepository : IAuthorRepository
    {
        LibraryContext dbContext;
        //public AuthorRepository(LibraryContext libCon)
        public AuthorRepository()
        {
            dbContext = new LibraryContext();
            //dbContext = libCon;
        }

        public async Task<List<Avtor>> GetAll()
        {
            try {
                return await dbContext.Avtors.ToListAsync();
            } catch (Exception ex)
            {

            }
            return new List<Avtor>();
        }
        public async Task<Avtor?> GetById(int id)
        {
            return await dbContext.Avtors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Avtor avtor)
        {
            bool rv = false;
            var findAvtor = await dbContext.Avtors.FirstOrDefaultAsync(x => x.Id == avtor.Id);
            if (findAvtor == null)
                return false;
            findAvtor.Ime = avtor.Ime;
            findAvtor.Prezime = avtor.Prezime;
            findAvtor.Zemja = avtor.Zemja;
            findAvtor.GodinaNaRagjanje = avtor.GodinaNaRagjanje;
            return (await dbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var entityToRemove = await dbContext.Avtors.FirstOrDefaultAsync(x => x.Id == id);
            if (entityToRemove == null) return false;
            dbContext.Remove(entityToRemove);
            return (await dbContext.SaveChangesAsync() > 0);
        }

        public async Task<int> Create(Avtor avtor)
        {
            await dbContext.Avtors.AddAsync(avtor);
            await dbContext.SaveChangesAsync();
            return avtor.Id;
        }
    }

   
}
