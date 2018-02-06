﻿using System.ComponentModel.DataAnnotations;
using LotterySyndicate.API.Entities;

namespace LotterySyndicate.API.Models
{
    public class LotteryNumberDto
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public bool IsLuckyStar { get; set; }
        //public LotteryLine LotteryLine { get; set; }
        //public int LotteryLineId { get; set; }
    }
}