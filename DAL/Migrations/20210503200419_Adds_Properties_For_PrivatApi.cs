using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Adds_Properties_For_PrivatApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Card",
                table: "UserBankAccounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MerchantId",
                table: "UserBankAccounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserBankAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Card",
                table: "UserBankAccounts");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "UserBankAccounts");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserBankAccounts");
        }
    }
}
