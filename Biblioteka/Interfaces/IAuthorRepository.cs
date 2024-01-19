using Biblioteka.BibliotekaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Avtor>> GetAll();
        Task<Avtor?> GetById(int id);
        Task<bool> Update(Avtor avtor);
        Task<bool> Delete(int id);
        Task<int> Create(Avtor avtor);
    }
}
