using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Models
{
    public class Admin
    {
        [Key]
        [MaxLength(15)]
        public string? AdminID { get; set; }

        public string? Username { get; set; }

        public string Password { get; set; }

        public string NIC { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string EDID { get; set; }

        public ElectionDP ElectionDP { get; set; }

        public ICollection<GramaNiladhari> gramaNiladharis { get; set; } = new List<GramaNiladhari>();



    }
}
