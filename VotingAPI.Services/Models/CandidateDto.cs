using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Models;

namespace VotingAPI.Services.Models
{
    public class CandidateDto
    {
        [Key]
        public string CID { get; set; }

        public string NIC { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string PartyName { get; set; }

      

        public string DID { get; set; }
    }
}
