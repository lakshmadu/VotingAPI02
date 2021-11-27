using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Models
{
    public class Result
    {
        [Key]
        public string? DID { get; set; }

        public string? District{ get; set; }

        public int Count { get; set; }

        public string? EDID { get; set; }

        public ElectionDP? ElectionDP { get; set; }

        public ICollection<Candidate> candidates { get; set; } = new List<Candidate>();

    }
}
