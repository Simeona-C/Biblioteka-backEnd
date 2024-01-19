using Biblioteka.BibliotekaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Interfaces
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAll();
        Task<Member?> GetById(int id);
        Task<bool> Update(Member member);
        Task<bool> Delete(int id);
        Task<int> Create(Member member);
    }
}
