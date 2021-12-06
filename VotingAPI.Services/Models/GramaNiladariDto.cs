﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Services.Models
{
    public class GramaNiladariDto
    {
        [Key]
        public string? GNID { get; set; }

        public string? FullName { get; set; }

        public string? Password { get; set; }

        public string? GNDivision { get; set; }

        public string? DSDivision { get; set; }

        public string? AdminID { get; set; }

    }
}
