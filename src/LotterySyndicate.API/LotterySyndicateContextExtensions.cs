using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotterySyndicate.API.Entities;

namespace LotterySyndicate.API
{
    public static class LotterySyndicateContextExtensions
    {
        private  static Random rand = new Random();
        public static void EnsureSeedForContext(this LotterySyndicateContext context)
        {
            if (context.LotteryTickets.Any())
            {
                return;
            }

            var startDate = new DateTime(2018, 02, 06);
            var lotteryTickets = new List<LotteryTicket>();

            //generate some lottery lines!
            for (int i = 0; i < 3; i++)
            {
                var numberOfLines = rand.Next(1, 5);
                var seedLotteryLinesSet = new List<LotteryLine>();

                while (seedLotteryLinesSet.Count < numberOfLines)
                {
                    seedLotteryLinesSet.Add(new LotteryLine()
                    {
                        LotteryNumbers = GenerateNumbers()
                    });
                }

                var ticketToAdd = new LotteryTicket()
                {
                    DrawDate = startDate,
                    LotteryLines = seedLotteryLinesSet
                };

                lotteryTickets.Add(ticketToAdd);
                startDate = startDate.AddDays(-7);
            }

            context.LotteryTickets.AddRange(lotteryTickets);
            context.SaveChanges();
        }

        private static ICollection<LotteryNumber> GenerateNumbers()
        {
            var lotteryNumbers = new List<LotteryNumber>();
            for (int i = 0; i < 6; i++)
            {
                var randomNumber = rand.Next(1, 50);
                while (lotteryNumbers.Any(n => n.Number == randomNumber))
                {
                    randomNumber = rand.Next(1, 50);
                }
                lotteryNumbers.Add(new LotteryNumber()
                {
                    Number = randomNumber,
                    IsLuckyStar = false
                });
            }
            for (int i = 0; i < 2; i++)
            {
                var randomNumber = rand.Next(1, 12);
                while (lotteryNumbers.Any(n => n.Number == randomNumber && n.IsLuckyStar))
                {
                    randomNumber = rand.Next(1, 50);
                }
                lotteryNumbers.Add(new LotteryNumber()
                {
                    Number = randomNumber,
                    IsLuckyStar = true
                });
            }
            return lotteryNumbers.ToList();
        }
    }
}
