using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingAPI.DataAccess.Migrations
{
    public partial class postalcodeToVoter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Voters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Voters");
        }
    }
}
