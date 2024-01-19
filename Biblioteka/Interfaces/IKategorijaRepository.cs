using Biblioteka.BibliotekaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Interfaces
{
    public interface IKategorijaRepository
    {
        Task<List<Kategorija>> GetAll();
        Task<Kategorija?> GetById(int id);
        Task<bool> Update(Kategorija kategorija);
        Task<bool> Delete(int id);
        Task<int> Create(Kategorija kategorija);
    }
}
