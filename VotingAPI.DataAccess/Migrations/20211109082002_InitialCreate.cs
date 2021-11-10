using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingAPI.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectionDPs",
                columns: table => new
                {
                    EDID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectionDPs", x => x.EDID);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EDID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElectionDPEDID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admins_ElectionDPs_ElectionDPEDID",
                        column: x => x.ElectionDPEDID,
                        principalTable: "ElectionDPs",
                        principalColumn: "EDID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    DID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    EDID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElectionDPEDID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.DID);
                    table.ForeignKey(
                        name: "FK_Results_ElectionDPs_ElectionDPEDID",
                        column: x => x.ElectionDPEDID,
                        principalTable: "ElectionDPs",
                        principalColumn: "EDID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GramaNiladharis",
                columns: table => new
                {
                    GNID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GNDivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSDivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminID = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GramaNiladharis", x => x.GNID);
                    table.ForeignKey(
                        name: "FK_GramaNiladharis_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    PartyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminID = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyName);
                    table.ForeignKey(
                        name: "FK_Parties_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                columns: table => new
                {
                    VNIC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    Vote = table.Column<bool>(type: "bit", nullable: false),
                    GNID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GramaNiladhariGNID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.VNIC);
                    table.ForeignKey(
                        name: "FK_Voters_GramaNiladharis_GramaNiladhariGNID",
                        column: x => x.GramaNiladhariGNID,
                        principalTable: "GramaNiladharis",
                        principalColumn: "GNID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NIC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyName1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultDID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CID);
                    table.ForeignKey(
                        name: "FK_Candidates_Parties_PartyName1",
                        column: x => x.PartyName1,
                        principalTable: "Parties",
                        principalColumn: "PartyName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_Results_ResultDID",
                        column: x => x.ResultDID,
                        principalTable: "Results",
                        principalColumn: "DID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voter_Candidates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VNIC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoterVNIC = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateCID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voter_Candidates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Voter_Candidates_Candidates_CandidateCID",
                        column: x => x.CandidateCID,
                        principalTable: "Candidates",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voter_Candidates_Voters_VoterVNIC",
                        column: x => x.VoterVNIC,
                        principalTable: "Voters",
                        principalColumn: "VNIC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminID", "Address", "EDID", "ElectionDPEDID", "FullName", "NIC", "Password", "Username" },
                values: new object[,]
                {
                    { "Admin01", "Colombo", "Elec01", null, "Inbran Ahamed Rashad", "993070157v", "Rashad123", "adminRashad" },
                    { "Admin02", "Kurunegala", "Elec01", null, "Lakshan", "20000061035", "Lak123", "adminLak" },
                    { "Admin03", "colombo", "Elec02", null, "Madara bodani", "20000142256", "mada123", "adminmadara" },
                    { "Admin04", "Kandy", "Elec02", null, "Waruni Imalsha", "20000458789", "waru123", "adminWaruni" }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "CID", "Address", "DID", "DateOfBirth", "FullName", "Gender", "NIC", "PartyName", "PartyName1", "ResultDID" },
                values: new object[,]
                {
                    { "Can1", "Colombo", "D01", new DateTime(2000, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lakshan Madubashika", 0, "200006101510", "Podhujana Peramuna", null, null },
                    { "Can2", "Kandy", "D02", new DateTime(1999, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ravishmad", 0, "19342360V", "Samagi Jana Balawegaya", null, null },
                    { "Can3", "Colombo", "D01", new DateTime(2000, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samadara", 1, "200006111510", "Podhujana Peramuna", null, null }
                });

            migrationBuilder.InsertData(
                table: "ElectionDPs",
                columns: new[] { "EDID", "Address", "DName", "Telephone" },
                values: new object[,]
                {
                    { "Elec01", "Fort city", "ColomboElectionDepartment", 112530550 },
                    { "Elec02", "Kengalla", "KandyElectionDepartment", 613457230 }
                });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "DID", "Count", "District", "EDID", "ElectionDPEDID" },
                values: new object[,]
                {
                    { "D02", 4000, "kandy", "Elec01", null },
                    { "D01", 5000, "Colombo", "Elec01", null }
                });

            migrationBuilder.InsertData(
                table: "Voter_Candidates",
                columns: new[] { "ID", "CID", "CandidateCID", "VNIC", "VoterVNIC" },
                values: new object[,]
                {
                    { 5, "Can1", null, "999300927v", null },
                    { 1, "Can1", null, "998300900v", null },
                    { 2, "Can2", null, "999300920v", null },
                    { 3, "Can1", null, "999300123v", null },
                    { 4, "Can2", null, "999300925v", null },
                    { 6, "Can2", null, "998300900v", null }
                });

            migrationBuilder.InsertData(
                table: "Voters",
                columns: new[] { "VNIC", "Address", "DateOfBirth", "FullName", "GNID", "Gender", "GramaNiladhariGNID", "MaritalStatus", "Occupation", "Vote" },
                values: new object[,]
                {
                    { "998300900v", "67/5,ranala road, Habarakada,Homagama", new DateTime(1998, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Imasha Divyanjalee", "GN001", 0, null, 1, "Marketing Asistant", true },
                    { "999300920v", "ududumbara", new DateTime(1999, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "samantha", "GN002", 0, null, 0, "Farmer", true },
                    { "999300123v", "Maharagama", new DateTime(1999, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "santha", "GN001", 0, null, 1, "Farmer", true },
                    { "999300925v", "Ragama", new DateTime(1999, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vimal", "GN001", 0, null, 0, "Farmer", true },
                    { "999300927v", "Katugasthota", new DateTime(1999, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sumane", "GN002", 0, null, 1, "Farmer", true }
                });

            migrationBuilder.InsertData(
                table: "GramaNiladharis",
                columns: new[] { "GNID", "AdminID", "DSDivision", "FullName", "GNDivision", "Password" },
                values: new object[,]
                {
                    { "GN001", "Admin01", "365", "Samaranayake", "Fort", "ko" },
                    { "GN002", "Admin01", "241", "Senanayake", "ududumbara", "htttt" },
                    { "GN003", "Admin02", "385", "Bandara", "piliyandala", "https" },
                    { "GN004", "Admin02", "251", "gimhan", "kakirawa", "htdoc" }
                });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "PartyName", "Address", "AdminID" },
                values: new object[,]
                {
                    { "Podhujana Peramuna", "Colombo", "Admin01" },
                    { "Samagi Jana Balawegaya", "Kandy", "Admin01" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_ElectionDPEDID",
                table: "Admins",
                column: "ElectionDPEDID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_PartyName1",
                table: "Candidates",
                column: "PartyName1");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ResultDID",
                table: "Candidates",
                column: "ResultDID");

            migrationBuilder.CreateIndex(
                name: "IX_GramaNiladharis_AdminID",
                table: "GramaNiladharis",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_AdminID",
                table: "Parties",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ElectionDPEDID",
                table: "Results",
                column: "ElectionDPEDID");

            migrationBuilder.CreateIndex(
                name: "IX_Voter_Candidates_CandidateCID",
                table: "Voter_Candidates",
                column: "CandidateCID");

            migrationBuilder.CreateIndex(
                name: "IX_Voter_Candidates_VoterVNIC",
                table: "Voter_Candidates",
                column: "VoterVNIC");

            migrationBuilder.CreateIndex(
                name: "IX_Voters_GramaNiladhariGNID",
                table: "Voters",
                column: "GramaNiladhariGNID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voter_Candidates");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Voters");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "GramaNiladharis");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ElectionDPs");
        }
    }
}
