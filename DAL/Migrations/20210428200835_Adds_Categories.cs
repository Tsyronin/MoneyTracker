using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Adds_Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserBankAccounts");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "UserBankAccounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBankAccounts_AppUserId",
                table: "UserBankAccounts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserBankAccountId",
                table: "Expenses",
                column: "UserBankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AppUserId",
                table: "Categories",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_UserBankAccounts_UserBankAccountId",
                table: "Expenses",
                column: "UserBankAccountId",
                principalTable: "UserBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBankAccounts_AspNetUsers_AppUserId",
                table: "UserBankAccounts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_UserBankAccounts_UserBankAccountId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBankAccounts_AspNetUsers_AppUserId",
                table: "UserBankAccounts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_UserBankAccounts_AppUserId",
                table: "UserBankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_UserBankAccountId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "UserBankAccounts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserBankAccounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
