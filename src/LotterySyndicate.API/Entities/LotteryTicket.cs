using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LotterySyndicate.API.Entities
{
    public class LotteryTicket
    {
        public int Id { get; set; }
        [Required]
        public DateTime DrawDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchasedFromAddress { get; set; }

        //TODO: DigitalImageOfTicket
        //TODO: Who purchased the ticket
        //TODO: Image of shop

        public ICollection<LotteryLine> LotteryLines { get; set; } = new List<LotteryLine>();
        //public ICollection<LotteryNumber> LotteryNumber { get; set; } = new List<LotteryNumber>();
    }
}
