using Biblioteka.BibliotekaModel;
using Biblioteka.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LIBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        
        // GET: api/<MemberController>
        [HttpGet]
        public async Task<List<Member>> Get()
        {
            var result = await _memberRepository.GetAll();
            return result;
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public async Task<Member?> Get(int id)
        {
            var result = await _memberRepository.GetById(id);
            return result;
        }

        // POST api/<MemberController>
        [HttpPost]
        public async Task<int> Post([FromBody] Member member)
        {
            var result = await _memberRepository.Create(member);
            return result;
        }

        // PUT api/<MemberController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Member member) 
        {
            var result = await _memberRepository.Update(member); 
            return result;
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await _memberRepository.Delete(id);
            return result;
        }
    }
}
