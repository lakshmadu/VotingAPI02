using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Models;

namespace VotingAPI.DataAccess
{
    public class VotingDbContext : DbContext
    {
        public VotingDbContext(DbContextOptions<VotingDbContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<ElectionDP> ElectionDPs { get; set; }
        public DbSet<GramaNiladhari> GramaNiladharis { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Voter_Candidate> Voter_Candidates { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=VotingDB;Trusted_Connection=True;MultipleActiveResultSets=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }*/

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Admin>().HasData(new Admin[]
        //     {
        //         new Admin{AdminID="Admin01", Username="adminRashad",Password="Rashad123", NIC="993070157v",FullName="Inbran Ahamed Rashad", Address="Colombo",EDID="Elec01"},
        //         new Admin{AdminID="Admin02", Username="adminLak", Password="Lak123", NIC="20000061035", FullName ="Lakshan", Address="Kurunegala", EDID="Elec01"},
        //         new Admin{AdminID="Admin03", Username="adminmadara", Password="mada123", NIC="20000142256", FullName ="Madara bodani", Address="colombo", EDID="Elec02"},
        //         new Admin{AdminID="Admin04", Username="adminWaruni", Password="waru123", NIC="20000458789", FullName ="Waruni Imalsha", Address="Kandy", EDID="Elec02"}
        //     });

        //     modelBuilder.Entity<Candidate>().HasData(new Candidate[]
        //     {
        //         new Candidate{CID="Can1",NIC="200006101510",FullName="Lakshan Madubashika",Address="Colombo",DateOfBirth=Convert.ToDateTime("Mar 1,2000"),Gender=Gender.Male,PName="Podhujana Peramuna", DID="D01"},
        //         new Candidate{CID="Can2", NIC="19342360V", FullName="Ravishmad", Address="Kandy",DateOfBirth=Convert.ToDateTime("Feb 28 1999"), Gender=Gender.Male, PName="Samagi Jana Balawegaya", DID="D02"},
        //         new Candidate{CID="Can3",NIC="200006111510",FullName="Samadara",Address="Colombo",DateOfBirth=Convert.ToDateTime("Mar 2,2000"),Gender=Gender.Female,PName="Podhujana Peramuna", DID="D01"}
        //     });
        //     modelBuilder.Entity<ElectionDP>().HasData(new ElectionDP[]
        //     {
        //         new ElectionDP{EDID="Elec01", DName="ColomboElectionDepartment", Telephone=0112530550,Address="Fort city"},
        //         new ElectionDP{EDID="Elec02", DName="KandyElectionDepartment", Telephone=0613457230, Address="Kengalla"}
        //     });

        //     modelBuilder.Entity<GramaNiladhari>().HasData(new GramaNiladhari[]
        //     {
        //         new GramaNiladhari{GNID="GN001",FullName="Samaranayake", Password="ko", GNDivision="Fort", DSDivision="365",AdminID="Admin01"},
        //         new GramaNiladhari{GNID="GN002",FullName="Senanayake", Password="htttt", GNDivision="ududumbara", DSDivision="241",AdminID="Admin01"},
        //         new GramaNiladhari{GNID="GN003",FullName="Bandara", Password="https", GNDivision="piliyandala", DSDivision="385",AdminID="Admin02"},
        //         new GramaNiladhari{GNID="GN004",FullName="gimhan", Password="htdoc", GNDivision="kakirawa", DSDivision="251",AdminID="Admin02"}

        //     });

        //     modelBuilder.Entity<Party>().HasData(new Party[]
        //     {
        //         new Party{PName="Podhujana Peramuna",Address="Colombo", TelphoneNo="0716510096",AdminID="Admin01"},
        //         new Party{PName="Samagi Jana Balawegaya",Address="Kandy", TelphoneNo="0128894561",AdminID="Admin01"}
        //     });
        //     modelBuilder.Entity<Result>().HasData(new Result[]
        //     {
        //         new Result{DID="D01",District="Colombo", Count=5000,EDID="Elec01"},
        //         new Result{DID="D02",District="kandy", Count=4000,EDID="Elec01"}
        //     });
        //     modelBuilder.Entity<Voter>().HasData(new Voter[]
        //     {
        //         new Voter{VNIC="998300900v",FullName="Imasha Divyanjalee", Address="67/5,ranala road, Habarakada,Homagama", PostalCode=91250,DateOfBirth= Convert.ToDateTime("Nov 25, 1998"), Occupation="Marketing Asistant",MaritalStatus=MaritalStatus.UnMarried, Vote=true,GNID="GN001"},
        //         new Voter{VNIC="999300920v",FullName="samantha", Address="ududumbara",PostalCode=91200, DateOfBirth= Convert.ToDateTime("Nov 25, 1999"), Occupation="Farmer",MaritalStatus=MaritalStatus.Married, Vote=true,GNID="GN002"},
        //         new Voter{VNIC="999300123v",FullName="santha", Address="Maharagama",PostalCode=91300, DateOfBirth= Convert.ToDateTime("Nov 25, 1999"), Occupation="Farmer",MaritalStatus=MaritalStatus.UnMarried, Vote=true,GNID="GN001"},
        //         new Voter{VNIC="999300925v",FullName="Vimal", Address="Ragama",PostalCode=91232, DateOfBirth= Convert.ToDateTime("Nov 25, 1999"), Occupation="Farmer",MaritalStatus=MaritalStatus.Married, Vote=true,GNID="GN001"},
        //         new Voter{VNIC="999300927v",FullName="sumane", Address="Katugasthota",PostalCode=91900, DateOfBirth= Convert.ToDateTime("Nov 25, 1999"), Occupation="Farmer",MaritalStatus=MaritalStatus.UnMarried, Vote=true,GNID="GN002"}
        //     });
        //     modelBuilder.Entity<Voter_Candidate>().HasData(new Voter_Candidate[]
        //     {
        //         new Voter_Candidate{ID=1, VNIC="998300900v", CID="Can1"},
        //         new Voter_Candidate{ID=2, VNIC="999300920v", CID="Can2"},
        //         new Voter_Candidate{ID=3, VNIC="999300123v", CID="Can1"},
        //         new Voter_Candidate{ID=4, VNIC="999300925v", CID="Can2"},
        //         new Voter_Candidate{ID=5, VNIC="999300927v", CID="Can1"},
        //         new Voter_Candidate{ID=6, VNIC="998300900v", CID="Can2"}
        //     });
        // }
    }
}
