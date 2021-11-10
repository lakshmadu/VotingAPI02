using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Models;

namespace VotingAPI.Services.Voters
{
    public interface IVoterRepository
    {
        public Voter GetVoter(string id);
    }
}
