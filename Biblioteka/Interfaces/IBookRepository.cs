using Biblioteka.BibliotekaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book?> GetById(int id);
        Task<bool> Update(Book book);
        Task<bool> Delete(int id);
        Task<int> Create(Book book);
    }
}
