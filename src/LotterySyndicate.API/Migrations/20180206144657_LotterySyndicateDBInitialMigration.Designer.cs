using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LotterySyndicate.API.Entities;

namespace LotterySyndicate.API.Migrations
{
    [DbContext(typeof(LotterySyndicateContext))]
    [Migration("20180206144657_LotterySyndicateDBInitialMigration")]
    partial class LotterySyndicateDBInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LotterySyndicate.API.Entities.LotteryLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LotteryTicketId");

                    b.HasKey("Id");

                    b.HasIndex("LotteryTicketId");

                    b.ToTable("LotteryLines");
                });

            modelBuilder.Entity("LotterySyndicate.API.Entities.LotteryNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsLuckyStar");

                    b.Property<int>("LotteryLineId");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("LotteryLineId");

                    b.ToTable("LotteryNumbers");
                });

            modelBuilder.Entity("LotterySyndicate.API.Entities.LotteryTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DrawDate");

                    b.Property<DateTime>("PurchaseDate");

                    b.Property<string>("PurchasedFromAddress");

                    b.HasKey("Id");

                    b.ToTable("LotteryTickets");
                });

            modelBuilder.Entity("LotterySyndicate.API.Entities.LotteryLine", b =>
                {
                    b.HasOne("LotterySyndicate.API.Entities.LotteryTicket", "LotteryTicket")
                        .WithMany("LotteryLines")
                        .HasForeignKey("LotteryTicketId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LotterySyndicate.API.Entities.LotteryNumber", b =>
                {
                    b.HasOne("LotterySyndicate.API.Entities.LotteryLine", "LotteryLine")
                        .WithMany("LotteryNumbers")
                        .HasForeignKey("LotteryLineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
