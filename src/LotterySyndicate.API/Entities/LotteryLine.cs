using System.Collections.Generic;
using System.Globalization;

namespace LotterySyndicate.API.Entities
{
    public class LotteryLine
    {
        public int Id { get; set; }
        public ICollection<LotteryNumber> LotteryNumbers { get; set; } = new List<LotteryNumber>();
        public LotteryTicket LotteryTicket { get; set; }
        public int LotteryTicketId { get; set; }
    }
}