// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VotingAPI.DataAccess;
#nullable disable

namespace VotingAPI.DataAccess.Migrations
{
    [DbContext(typeof(VotingDbContext))]
    partial class VotingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VotingAPI.Models.Admin", b =>
                {
                    b.Property<string>("AdminID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EDID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElectionDPEDID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.HasIndex("ElectionDPEDID");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            AdminID = "Admin01",
                            Address = "Colombo",
                            EDID = "Elec01",
                            FullName = "Inbran Ahamed Rashad",
                            NIC = "993070157v",
                            Password = "Rashad123",
                            Username = "adminRashad"
                        },
                        new
                        {
                            AdminID = "Admin02",
                            Address = "Kurunegala",
                            EDID = "Elec01",
                            FullName = "Lakshan",
                            NIC = "20000061035",
                            Password = "Lak123",
                            Username = "adminLak"
                        },
                        new
                        {
                            AdminID = "Admin03",
                            Address = "colombo",
                            EDID = "Elec02",
                            FullName = "Madara bodani",
                            NIC = "20000142256",
                            Password = "mada123",
                            Username = "adminmadara"
                        },
                        new
                        {
                            AdminID = "Admin04",
                            Address = "Kandy",
                            EDID = "Elec02",
                            FullName = "Waruni Imalsha",
                            NIC = "20000458789",
                            Password = "waru123",
                            Username = "adminWaruni"
                        });
                });

            modelBuilder.Entity("VotingAPI.Models.Candidate", b =>
                {
                    b.Property<string>("CID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("NIC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartyPName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ResultDID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CID");

                    b.HasIndex("PartyPName");

                    b.HasIndex("ResultDID");

                    b.ToTable("Candidates");

                    b.HasData(
                        new
                        {
                            CID = "Can1",
                            Address = "Colombo",
                            DID = "D01",
                            DateOfBirth = new DateTime(2000, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Lakshan Madubashika",
                            Gender = 0,
                            NIC = "200006101510",
                            PName = "Podhujana Peramuna"
                        },
                        new
                        {
                            CID = "Can2",
                            Address = "Kandy",
                            DID = "D02",
                            DateOfBirth = new DateTime(1999, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Ravishmad",
                            Gender = 0,
                            NIC = "19342360V",
                            PName = "Samagi Jana Balawegaya"
                        },
                        new
                        {
                            CID = "Can3",
                            Address = "Colombo",
                            DID = "D01",
                            DateOfBirth = new DateTime(2000, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Samadara",
                            Gender = 1,
                            NIC = "200006111510",
                            PName = "Podhujana Peramuna"
                        });
                });

            modelBuilder.Entity("VotingAPI.Models.ElectionDP", b =>
                {
                    b.Property<string>("EDID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.HasKey("EDID");

                    b.ToTable("ElectionDPs");

                    b.HasData(
                        new
                        {
                            EDID = "Elec01",
                            Address = "Fort city",
                            DName = "ColomboElectionDepartment",
                            Telephone = 112530550
                        },
                        new
                        {
                            EDID = "Elec02",
                            Address = "Kengalla",
                            DName = "KandyElectionDepartment",
                            Telephone = 613457230
                        });
                });

            modelBuilder.Entity("VotingAPI.Models.GramaNiladhari", b =>
                {
                    b.Property<string>("GNID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdminID")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("DSDivision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("GNDivision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GNID");

                    b.HasIndex("AdminID");

                    b.ToTable("GramaNiladharis");

                    b.HasData(
                        new
                        {
                            GNID = "GN001",
                            AdminID = "Admin01",
                            DSDivision = "365",
                            FullName = "Samaranayake",
                            GNDivision = "Fort",
                            Password = "ko"
                        },
                        new
                        {
                            GNID = "GN002",
                            AdminID = "Admin01",
                            DSDivision = "241",
                            FullName = "Senanayake",
                            GNDivision = "ududumbara",
                            Password = "htttt"
                        },
                        new
                        {
                            GNID = "GN003",
                            AdminID = "Admin02",
                            DSDivision = "385",
                            FullName = "Bandara",
                            GNDivision = "piliyandala",
                            Password = "https"
                        },
                        new
                        {
                            GNID = "GN004",
                            AdminID = "Admin02",
                            DSDivision = "251",
                            FullName = "gimhan",
                            GNDivision = "kakirawa",
                            Password = "htdoc"
                        });
                });

            modelBuilder.Entity("VotingAPI.Models.Party", b =>
                {
                    b.Property<string>("PName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminID")
                        .HasColumnType("nvarchar(15)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("TelphoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PName");

                    b.HasIndex("AdminID");

                    b.ToTable("Parties");

                    b.HasData(
                        new
                        {
                            PName = "Podhujana Peramuna",
                            Address = "Colombo",
                            AdminID = "Admin01",
                            TelphoneNo = "0716510096"
                        },
                        new
                        {
                            PName = "Samagi Jana Balawegaya",
                            Address = "Kandy",
                            AdminID = "Admin01",
                            TelphoneNo = "0128894561"
                        });
                });

            modelBuilder.Entity("VotingAPI.Models.Result", b =>
                {
                    b.Property<string>("DID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EDID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElectionDPEDID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DID");

                    b.HasIndex("ElectionDPEDID");

                    b.ToTable("Results");

                    b.HasData(
                        new
                        {
                            DID = "D01",
                            Count = 5000,
                            District = "Colombo",
                            EDID = "Elec01"
                        },
                        new
                        {
                            DID = "D02",
                            Count = 4000,
                            District = "kandy",
                            EDID = "Elec01"
                        });
                });

            modelBuilder.Entity("VotingAPI.Models.Voter", b =>
                {
                    b.Property<string>("VNIC")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GNID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("GramaNiladhariGNID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostalCode")
                        .HasColumnType("int");

                    b.Property<bool>("Vote")
                        .HasColumnType("bit");

                    b.HasKey("VNIC");

                    b.HasIndex("GramaNiladhariGNID");

                    b.ToTable("Voters");

                    b.HasData(
                        new
                        {
                            VNIC = "998300900v",
                            Address = "67/5,ranala road, Habarakada,Homagama",
                            DateOfBirth = new DateTime(1998, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Imasha Divyanjalee",
                            GNID = "GN001",
                            Gender = 0,
                            MaritalStatus = 1,
                            Occupation = "Marketing Asistant",
                            PostalCode = 91250,
                            Vote = true
                        },
                        new
                        {
                            VNIC = "999300920v",
                            Address = "ududumbara",
                            DateOfBirth = new DateTime(1999, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "samantha",
                            GNID = "GN002",
                            Gender = 0,
                            MaritalStatus = 0,
                            Occupation = "Farmer",
                            PostalCode = 91200,
                            Vote = true
                        },
                        new
                        {
                            VNIC = "999300123v",
                            Address = "Maharagama",
                            DateOfBirth = new DateTime(1999, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "santha",
                            GNID = "GN001",
                            Gender = 0,
                            MaritalStatus = 1,
                            Occupation = "Farmer",
                            PostalCode = 91300,
                            Vote = true
                        },
                        new
                        {
                            VNIC = "999300925v",
                            Address = "Ragama",
                            DateOfBirth = new DateTime(1999, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Vimal",
                            GNID = "GN001",
                            Gender = 0,
                            MaritalStatus = 0,
                            Occupation = "Farmer",
                            PostalCode = 91232,
                            Vote = true
                        },
                        new
                        {
                            VNIC = "999300927v",
                            Address = "Katugasthota",
                            DateOfBirth = new DateTime(1999, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "sumane",
                            GNID = "GN002",
                            Gender = 0,
                            MaritalStatus = 1,
                            Occupation = "Farmer",
                            PostalCode = 91900,
                            Vote = true
                        });
                });

            modelBuilder.Entity("VotingAPI.Models.Voter_Candidate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CandidateCID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VNIC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VoterVNIC")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("CandidateCID");

                    b.HasIndex("VoterVNIC");

                    b.ToTable("Voter_Candidates");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CID = "Can1",
                            VNIC = "998300900v"
                        },
                        new
                        {
                            ID = 2,
                            CID = "Can2",
                            VNIC = "999300920v"
                        },
                        new
                        {
                            ID = 3,
                            CID = "Can1",
                            VNIC = "999300123v"
                        },
                        new
                        {
                            ID = 4,
                            CID = "Can2",
                            VNIC = "999300925v"
                        },
                        new
                        {
                            ID = 5,
                            CID = "Can1",
                            VNIC = "999300927v"
                        },
                        new
                        {
                            ID = 6,
                            CID = "Can2",
                            VNIC = "998300900v"
                        });
                });

            modelBuilder.Entity("VotingAPI.Models.Admin", b =>
                {
                    b.HasOne("VotingAPI.Models.ElectionDP", "ElectionDP")
                        .WithMany("admins")
                        .HasForeignKey("ElectionDPEDID");

                    b.Navigation("ElectionDP");
                });

            modelBuilder.Entity("VotingAPI.Models.Candidate", b =>
                {
                    b.HasOne("VotingAPI.Models.Party", "Party")
                        .WithMany("candidates")
                        .HasForeignKey("PartyPName");

                    b.HasOne("VotingAPI.Models.Result", "Result")
                        .WithMany("candidates")
                        .HasForeignKey("ResultDID");

                    b.Navigation("Party");

                    b.Navigation("Result");
                });

            modelBuilder.Entity("VotingAPI.Models.GramaNiladhari", b =>
                {
                    b.HasOne("VotingAPI.Models.Admin", "Admin")
                        .WithMany("gramaNiladharis")
                        .HasForeignKey("AdminID");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("VotingAPI.Models.Party", b =>
                {
                    b.HasOne("VotingAPI.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminID");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("VotingAPI.Models.Result", b =>
                {
                    b.HasOne("VotingAPI.Models.ElectionDP", "ElectionDP")
                        .WithMany("results")
                        .HasForeignKey("ElectionDPEDID");

                    b.Navigation("ElectionDP");
                });

            modelBuilder.Entity("VotingAPI.Models.Voter", b =>
                {
                    b.HasOne("VotingAPI.Models.GramaNiladhari", "GramaNiladhari")
                        .WithMany()
                        .HasForeignKey("GramaNiladhariGNID");

                    b.Navigation("GramaNiladhari");
                });

            modelBuilder.Entity("VotingAPI.Models.Voter_Candidate", b =>
                {
                    b.HasOne("VotingAPI.Models.Candidate", "Candidate")
                        .WithMany("voter_Candidates")
                        .HasForeignKey("CandidateCID");

                    b.HasOne("VotingAPI.Models.Voter", "Voter")
                        .WithMany("voter_Candidates")
                        .HasForeignKey("VoterVNIC");

                    b.Navigation("Candidate");

                    b.Navigation("Voter");
                });

            modelBuilder.Entity("VotingAPI.Models.Admin", b =>
                {
                    b.Navigation("gramaNiladharis");
                });

            modelBuilder.Entity("VotingAPI.Models.Candidate", b =>
                {
                    b.Navigation("voter_Candidates");
                });

            modelBuilder.Entity("VotingAPI.Models.ElectionDP", b =>
                {
                    b.Navigation("admins");

                    b.Navigation("results");
                });

            modelBuilder.Entity("VotingAPI.Models.Party", b =>
                {
                    b.Navigation("candidates");
                });

            modelBuilder.Entity("VotingAPI.Models.Result", b =>
                {
                    b.Navigation("candidates");
                });

            modelBuilder.Entity("VotingAPI.Models.Voter", b =>
                {
                    b.Navigation("voter_Candidates");
                });
#pragma warning restore 612, 618
        }
    }
}

