using System.ComponentModel.DataAnnotations;

namespace LotterySyndicate.API.Entities
{
    public class LotteryNumber
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public bool IsLuckyStar { get; set; }
        public LotteryLine LotteryLine { get; set; }
        public int LotteryLineId { get; set; }
    }
}