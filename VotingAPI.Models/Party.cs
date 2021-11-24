using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Models
{
    public class Party
    {
        [Key]
        public string? PartyName { get; set; }

        public string? Address { get; set; }

        public string? TelphoneNo { get; set; }     

        public string? AdminID { get; set; }

        public Admin Admin { get; set; }

        public ICollection<Candidate> candidates { get; set; } = new List<Candidate>();

        


    }
}
