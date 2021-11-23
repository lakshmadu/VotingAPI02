using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingAPI.DataAccess.Migrations
{
    public partial class TPtoParty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Voters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TelphoneNo",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "TelphoneNo",
                table: "Parties");
        }
    }
}
