using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Models
{
    public class Candidate
    {
        [Key]
        public string CID { get; set; }

        public string NIC{ get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender  { get; set; }

        public string PartyName { get; set; }

        public Party Party { get; set; }

        public string DID { get; set; }

        public Result Result { get; set; }

        public ICollection<Voter_Candidate> voter_Candidates { get; set; } = new List<Voter_Candidate>();

    }
}
