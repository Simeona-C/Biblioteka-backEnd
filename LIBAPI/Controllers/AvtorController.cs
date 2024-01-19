using Biblioteka.BibliotekaModel;
using Biblioteka;
using Biblioteka.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LIBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvtorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AvtorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }


        // GET: api/<AvtorController>
        [HttpGet]
        public async Task<List<Avtor>> Get()
        {
            var result = await _authorRepository.GetAll();
            return result;
        }

        // GET api/<AvtorController>/5
        [HttpGet("{id}")]
        public async Task<Avtor?> Get(int id)
        {
            var result = await _authorRepository.GetById(id);
            return result;
        }

        // POST api/<AvtorController>
        [HttpPost]
        public async Task<int> Post([FromBody] Avtor avtor)
        {
            var result = await _authorRepository.Create(avtor);
            return result;
        }

        // PUT api/<AvtorController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Avtor avtor)
        {
            var result = await _authorRepository.Update(avtor);
            return result;
        }

        // DELETE api/<AvtorController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await _authorRepository.Delete(id);
            return result;
        }
    }
}
