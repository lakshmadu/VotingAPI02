﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Services.Security
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
