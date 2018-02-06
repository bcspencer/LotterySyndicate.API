using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LotterySyndicate.API.Migrations
{
    public partial class LotterySyndicateDBInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LotteryTickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrawDate = table.Column<DateTime>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchasedFromAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotteryTickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LotteryLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LotteryTicketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotteryLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotteryLines_LotteryTickets_LotteryTicketId",
                        column: x => x.LotteryTicketId,
                        principalTable: "LotteryTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LotteryNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsLuckyStar = table.Column<bool>(nullable: false),
                    LotteryLineId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotteryNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotteryNumbers_LotteryLines_LotteryLineId",
                        column: x => x.LotteryLineId,
                        principalTable: "LotteryLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LotteryLines_LotteryTicketId",
                table: "LotteryLines",
                column: "LotteryTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_LotteryNumbers_LotteryLineId",
                table: "LotteryNumbers",
                column: "LotteryLineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LotteryNumbers");

            migrationBuilder.DropTable(
                name: "LotteryLines");

            migrationBuilder.DropTable(
                name: "LotteryTickets");
        }
    }
}
