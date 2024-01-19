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
   
    public class BookRepository : IBookRepository
    {
        LibraryContext dbContext = new LibraryContext();
        public BookRepository() 
        {
        }

        public async Task<List<Book>> GetAll()
        {
            return await dbContext.Books.ToListAsync();
        }
        public async Task<Book?> GetById(int id) 
        {
            return await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Book book)
        {
            bool rv = false;
            var findBook = await dbContext.Books.FirstOrDefaultAsync(x=>x.Id == book.Id);
            if (findBook == null)
                return false;
            findBook.Status = book.Status;
            findBook.Jazik = book.Jazik;
            findBook.IzdavackaKukja = book.IzdavackaKukja;
            findBook.AvtorId = book.AvtorId;
            findBook.Naslov = book.Naslov;
            return (await dbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var entityToRemove = await dbContext.Books.FirstOrDefaultAsync(x=>x.Id ==id);
            if (entityToRemove == null) return false;
            dbContext.Remove(entityToRemove);
            return (await dbContext.SaveChangesAsync() > 0);
        }

        public async Task<int> Create(Book book)
        {
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync ();
            return book.Id;
        }
    }

   
}
