using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Models
{
    public class Voter
    {
        [Key]
        public string VNIC { get; set; }

        public string FullName { get; set; }

        public int MyProperty { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }
        
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string  Occupation { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public bool Vote { get; set; }

        public string GNID { get; set; }

        public GramaNiladhari GramaNiladhari { get; set; }

        public ICollection<Voter_Candidate> voter_Candidates { get; set; } = new List<Voter_Candidate>();



    }
}
