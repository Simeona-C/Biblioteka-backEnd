using Biblioteka.BibliotekaModel;
using Biblioteka;
using Biblioteka.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LIBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorijaController : ControllerBase
    {
        private readonly IKategorijaRepository _kategorijaRepository;

        public KategorijaController(IKategorijaRepository kategorijaRepository)
        {
            _kategorijaRepository = kategorijaRepository;
        }


        // GET: api/<KategorijaController>
        [HttpGet]
        public async Task<List<Kategorija>> Get()
        {
            var result = await _kategorijaRepository.GetAll();
            return result;
        }

        // GET api/<KategorijaController>/5
        [HttpGet("{id}")]
        public async Task<Kategorija?> Get(int id)
        {
            var result = await _kategorijaRepository.GetById(id);
            return result;
        }

        // POST api/<KategorijaController>
        [HttpPost]
        public async Task<int> Post([FromBody] Kategorija kategorija)
        {
            var result = await _kategorijaRepository.Create(kategorija);
            return result;
        }

        // PUT api/<KategorijaController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Kategorija kategorija)
        {
            var result = await _kategorijaRepository.Update(kategorija);
            return result;
        }

        // DELETE api/<KategorijaController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await _kategorijaRepository.Delete(id);
            return result;
        }
    }
}
