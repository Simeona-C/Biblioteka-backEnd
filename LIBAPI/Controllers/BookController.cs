using Biblioteka.BibliotekaModel;
using Biblioteka.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LIBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


       // GET: api/<BookController>
        [HttpGet]
        public async Task<List<Book>> Get()
        {
            var result = await _bookRepository.GetAll();
            return result;
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<Book?> Get(int id)
        {
            var result = await _bookRepository.GetById(id);
            return result;
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<int> Post([FromBody] Book book)
        {
            var result = await _bookRepository.Create(book);
            return result;
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Book book) 
        {
            var result = await _bookRepository.Update(book); 
            return result;
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await _bookRepository.Delete(id);
            return result;
        }
    }
}
