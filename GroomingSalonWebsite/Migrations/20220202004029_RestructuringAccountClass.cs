using Microsoft.EntityFrameworkCore.Migrations;

namespace GroomingSalonWebsite.Migrations
{
    public partial class RestructuringAccountClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountEmail",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountPassword",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "InputId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_InputId",
                table: "Accounts",
                column: "InputId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_InputId",
                table: "Accounts",
                column: "InputId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_InputId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_InputId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "InputId",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "AccountEmail",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Accounts",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountPassword",
                table: "Accounts",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }
    }
}
