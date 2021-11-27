using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.DataAccess.Migrations
{
    public partial class updateImageParty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Parties",
                keyColumn: "PName",
                keyValue: "Podhujana Peramuna",
                column: "TelphoneNo",
                value: "0716510096");

            migrationBuilder.UpdateData(
                table: "Parties",
                keyColumn: "PName",
                keyValue: "Samagi Jana Balawegaya",
                column: "TelphoneNo",
                value: "0128894561");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Parties",
                keyColumn: "PName",
                keyValue: "Podhujana Peramuna",
                column: "TelphoneNo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parties",
                keyColumn: "PName",
                keyValue: "Samagi Jana Balawegaya",
                column: "TelphoneNo",
                value: null);
        }
    }
}
