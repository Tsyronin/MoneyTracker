using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Adds_Expenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserBankAccountId = table.Column<int>(nullable: false),
                    BankExpenseId = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Mcc = table.Column<int>(nullable: false),
                    Hold = table.Column<bool>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    OperationAmount = table.Column<int>(nullable: false),
                    CurrencyCode = table.Column<int>(nullable: false),
                    CommissionRate = table.Column<int>(nullable: false),
                    CashbackAmount = table.Column<int>(nullable: false),
                    Balance = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ReceiptId = table.Column<string>(nullable: true),
                    CounterEdrpou = table.Column<string>(nullable: true),
                    CounterIban = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
