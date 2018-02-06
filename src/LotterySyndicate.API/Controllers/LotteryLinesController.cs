using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotterySyndicate.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LotterySyndicate.API.Controllers
{
    [Route("api/[controller]")]
    public class LotteryLinesController : Controller
    {
        private ILotterySyndicateRepository _lotterySyndicateRepository;

        public LotteryLinesController(ILotterySyndicateRepository lotterySyndicateRepository)
        {
            _lotterySyndicateRepository = lotterySyndicateRepository;
        }

        // GET: api/values
        [HttpGet()]
        public IActionResult GetLines()
        {
            return Ok(_lotterySyndicateRepository.GetLines());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
