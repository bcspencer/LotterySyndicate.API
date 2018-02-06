using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore;

namespace LotterySyndicate.API.Entities
{
    public class LotterySyndicateContext : DbContext
    {
        public DbSet<LotteryTicket> LotteryTickets { get; set; }
        public DbSet<LotteryLine> LotteryLines { get; set; }
        public DbSet<LotteryNumber> LotteryNumbers { get; set; }

        public LotterySyndicateContext(DbContextOptions<LotterySyndicateContext> options) :base(options)
        {
            Database.Migrate();
        }
    }
}
