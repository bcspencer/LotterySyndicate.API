using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using LotterySyndicate.API.Entities;

namespace LotterySyndicate.API.Services
{
    public interface ILotterySyndicateRepository
    {
        IEnumerable<LotteryTicket> GetTickets();
        LotteryTicket GetTicket(int ticketId);
        bool TicketExists(int ticketId);
        IEnumerable<LotteryLine> GetLinesForTicket(int ticketId);
        IEnumerable<LotteryLine> GetLines();
        void AddTicket(LotteryTicket lotteryTicket);
        bool Save();

    }
}
