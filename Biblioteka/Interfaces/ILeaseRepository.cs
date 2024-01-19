using Biblioteka.BibliotekaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Interfaces
{
    public interface ILeaseRepository
    {
        Task<List<Lease>> GetAll();
        Task<Lease?> GetById(int id);
        Task<bool> Update(Lease lease);
        Task<bool> Delete(int id);
        Task<int> Create(Lease lease);
    }
}
