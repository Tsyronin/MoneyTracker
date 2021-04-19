using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Rename_Account_to_Token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Account",
                table: "UserBankAccounts");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "UserBankAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "UserBankAccounts");

            migrationBuilder.AddColumn<string>(
                name: "Account",
                table: "UserBankAccounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
