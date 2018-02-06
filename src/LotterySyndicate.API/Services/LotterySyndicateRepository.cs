using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotterySyndicate.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LotterySyndicate.API.Services
{
    public class LotterySyndicateRepository : ILotterySyndicateRepository
    {
        private LotterySyndicateContext _context;

        public LotterySyndicateRepository(LotterySyndicateContext context)
        {
            _context = context;
        }
        public IEnumerable<LotteryTicket> GetTickets()
        {
            return _context.LotteryTickets
                .Include(t => t.LotteryLines)
                .ThenInclude(t => t.LotteryNumbers)
                .ToList();
            //return _context.LotteryTickets.ToList();
        }

        public LotteryTicket GetTicket(int ticketId)
        {
            return _context.LotteryTickets
                .Include(t => t.LotteryLines)
                .ThenInclude(t => t.LotteryNumbers)
                .FirstOrDefault(t => t.Id == ticketId);
        }

        public bool TicketExists(int ticketId)
        {
            return _context.LotteryTickets.Any(t => t.Id == ticketId);
        }

        public IEnumerable<LotteryLine> GetLinesForTicket(int ticketId)
        {
            return _context.LotteryLines
                .Include(t => t.LotteryNumbers)
                .Where(t => t.LotteryTicketId == ticketId)
                .ToList();
        }

        public IEnumerable<LotteryLine> GetLines()
        {
            return _context.LotteryLines
                .Include(t => t.LotteryNumbers)
                .ToList();
        }

        public void AddTicket(LotteryTicket lotteryTicket)
        {
            _context.Add(lotteryTicket);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}