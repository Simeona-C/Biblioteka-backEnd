using Biblioteka.BibliotekaModel;
using Biblioteka;
using Biblioteka.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LIBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaseController : ControllerBase
    {
        private readonly ILeaseRepository _leaseRepository;

        public LeaseController(ILeaseRepository leaseRepository)
        {
            _leaseRepository = leaseRepository;
        }


        // GET: api/<LeaseController>
        [HttpGet]
        public async Task<List<Lease>> Get()
        {
            var result = await _leaseRepository.GetAll();
            return result;
        }

        // GET api/<LeaseController>/5
        [HttpGet("{id}")]
        public async Task<Lease?> Get(int id)
        {
            var result = await _leaseRepository.GetById(id);
            return result;
        }

        // POST api/<LeaseController>
        [HttpPost]
        public async Task<int> Post([FromBody] Lease lease)
        {
            var result = await _leaseRepository.Create(lease);
            return result;
        }

        // PUT api/<LeaseController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Lease lease)
        {
            var result = await _leaseRepository.Update(lease);
            return result;
        }

        // DELETE api/<LeaseController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await _leaseRepository.Delete(id);
            return result;
        }
    }
}
