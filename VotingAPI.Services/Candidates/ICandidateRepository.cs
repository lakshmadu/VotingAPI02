using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Models;

namespace VotingAPI.Services.Candidates
{
    public interface ICandidateRepository
    {
        public Candidate FindCandidate(string CID);
        public ICollection<Candidate> GetAllCandidate(string partyName);
        public Candidate createCandidate(Candidate candidate);
    }
}
