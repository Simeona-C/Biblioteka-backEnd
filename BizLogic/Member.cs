using Biblioteka.Interfaces;
using System;
using Biblioteka;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLogic
{
    public class Member
    {
        private readonly IMemberRepository _memberRepository;

        public Member(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<List<Biblioteka.BibliotekaModel.Member>> GetAll()
        {
            return await _memberRepository.GetAll();
        }

        public async Task<int> Create(Biblioteka.BibliotekaModel.Member member)
        {
            return await _memberRepository.Create(member);
        }

        public async Task<bool> Delete(int id)
        {
            return await (_memberRepository.Delete(id));
        }

        public async Task<Biblioteka.BibliotekaModel.Member> GetById(int id)
        {
            return await _memberRepository.GetById(id);

        }
        public async Task<bool> Update(Biblioteka.BibliotekaModel.Member member)
        {
            return await _memberRepository.Update(member);
        }
       
        
    }
}
