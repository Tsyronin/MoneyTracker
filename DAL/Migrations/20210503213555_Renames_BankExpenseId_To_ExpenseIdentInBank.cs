using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Renames_BankExpenseId_To_ExpenseIdentInBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankExpenseId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CashbackAmount",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CommissionRate",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CounterEdrpou",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CounterIban",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Hold",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Mcc",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "OperationAmount",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "ExpenseIdentInBank",
                table: "Expenses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseIdentInBank",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "BankExpenseId",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CashbackAmount",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommissionRate",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CounterEdrpou",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CounterIban",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyCode",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Hold",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Mcc",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperationAmount",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReceiptId",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
