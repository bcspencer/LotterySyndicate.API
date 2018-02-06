using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LotterySyndicate.API.Entities;

namespace LotterySyndicate.API.Models
{
    public class LotteryTicketForCreationDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime DrawDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchasedFromAddress { get; set; }

        //TODO: DigitalImageOfTicket
        //TODO: Who purchased the ticket
        //TODO: Image of shop

        public ICollection<LotteryLineDto> LotteryLines { get; set; } = new List<LotteryLineDto>();
        public ICollection<LotteryNumberDto> LotteryNumbers { get; set; } = new List<LotteryNumberDto>();
    }
}
