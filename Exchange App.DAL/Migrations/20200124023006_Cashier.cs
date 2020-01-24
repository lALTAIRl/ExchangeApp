using Microsoft.EntityFrameworkCore.Migrations;

namespace Exchange_App.DAL.Migrations
{
    public partial class Cashier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_Users_CashierId",
                table: "Exchanges");

            migrationBuilder.DropIndex(
                name: "IX_Exchanges_CashierId",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "CashierId",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Exchanges");

            migrationBuilder.AddColumn<string>(
                name: "Cashier",
                table: "Exchanges",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cashier",
                table: "Exchanges");

            migrationBuilder.AddColumn<int>(
                name: "CashierId",
                table: "Exchanges",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Exchanges",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_CashierId",
                table: "Exchanges",
                column: "CashierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_Users_CashierId",
                table: "Exchanges",
                column: "CashierId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
