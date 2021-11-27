using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Services.Models
{
    public class PartyDto
    {
        [Key]
        public string? PName { get; set; }

        public string? Address { get; set; }

        public string? TelphoneNo { get; set; }

        public byte[]? Image { get; set; }

        public string? AdminID { get; set; }
    }
}
