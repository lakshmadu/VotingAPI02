using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Models
{
    public class Voter_Candidate
    {
        [Key]
        public int ID { get; set; }

        public string? VNIC { get; set; }

        public Voter? Voter { get; set; }

        public string? CID { get; set; }

        public Candidate? Candidate { get; set; }       



    }
}
