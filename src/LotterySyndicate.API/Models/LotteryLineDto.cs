using System.Collections.Generic;
using LotterySyndicate.API.Entities;

namespace LotterySyndicate.API.Models
{
    public class LotteryLineDto
    {
        public int Id { get; set; }
        public ICollection<LotteryNumberDto> LotteryNumbers { get; set; } = new List<LotteryNumberDto>();
        //public LotteryTicket LotteryTicket { get; set; }
        //public int LotteryTicketId { get; set; }
    }
}