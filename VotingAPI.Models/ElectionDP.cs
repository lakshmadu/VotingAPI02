using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Models
{
    public class ElectionDP
    {
        [Key]
        public string? EDID { get; set; }

        public string? DName { get; set; }

        public int Telephone { get; set; }

        public string? Address { get; set; }

        public ICollection<Admin> admins { get; set; } = new List<Admin>();

        public ICollection<Result> results { get; set; } = new List<Result>();

    }
}
