using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LotterySyndicate.API.Entities;
using LotterySyndicate.API.Models;
using LotterySyndicate.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LotterySyndicate.API.Controllers
{
    [Route("api/[controller]")]
    public class LotteryTicketsController : Controller
    {
        private ILotterySyndicateRepository _lotterySyndicateRepository;

        public LotteryTicketsController(ILotterySyndicateRepository lotterySyndicateRepository)
        {
            _lotterySyndicateRepository = lotterySyndicateRepository;
        }

        // GET: api/values
        [HttpGet()]
        public IActionResult GetTickets()
        {
            var lotteryTicketEntities = _lotterySyndicateRepository.GetTickets();

            var results = Mapper.Map<IEnumerable<LotteryTicketDto>>(lotteryTicketEntities);

            return Ok(results);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetLotteryTicket")]
        public IActionResult GetLotteryTicket(int id)
        {
            if (!_lotterySyndicateRepository.TicketExists(id))
            {
                return NotFound();
            }

            var lotteryTicket = _lotterySyndicateRepository.GetTicket(id);
            var result = Mapper.Map<LotteryTicketDto>(lotteryTicket);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateLotteryTicket([FromBody] LotteryTicketForCreationDto lotteryTicket)
        {
            if (lotteryTicket == null)
            {
                return BadRequest();
            }

            //do some validation
            //MAYBE UNIQUE/COMPOUND KEY
            //then check the ModelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var finalLotteryTicket = Mapper.Map<LotteryTicket>(lotteryTicket);

            _lotterySyndicateRepository.AddTicket(finalLotteryTicket);

            if (!_lotterySyndicateRepository.Save())
            {
                return StatusCode(500, "A problem happened handling your request.");
            }

            var createdTicket = Mapper.Map<LotteryTicketDto>(finalLotteryTicket);

            return CreatedAtRoute("GetLotteryTicket", new {id = createdTicket.Id}, createdTicket);
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
