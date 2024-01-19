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
   
    public class KategorijaRepository : IKategorijaRepository
    {
        LibraryContext dbContext = new LibraryContext();
        public KategorijaRepository()
        {
        }

        public async Task<List<Kategorija>> GetAll()
        {
            return await dbContext.Kategorijas.ToListAsync();
        }
        public async Task<Kategorija?> GetById(int id)
        {
            return await dbContext.Kategorijas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Kategorija kategorija)
        {
            var findKategorija = await dbContext.Kategorijas.FirstOrDefaultAsync(x => x.Id == kategorija.Id);
            if (findKategorija == null)
                return false;
            findKategorija.Opis = kategorija.Opis;
            return (await dbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var entityToRemove = await dbContext.Kategorijas.FirstOrDefaultAsync(x => x.Id == id);
            if (entityToRemove == null) return false;
            dbContext.Remove(entityToRemove);
            return (await dbContext.SaveChangesAsync() > 0);
        }

        public async Task<int> Create(Kategorija kategorija)
        {
            await dbContext.Kategorijas.AddAsync(kategorija);
            await dbContext.SaveChangesAsync();
            return kategorija.Id;
        }
    }

   
}
