using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Models;
using VotingAPI.DataAccess;


namespace VotingAPI.Services.Candidates
{
   public class CandidateSqlServerService : ICandidateRepository
    {
        private readonly VotingDbContext _context;
        public CandidateSqlServerService(VotingDbContext context )
        {
            _context = context;
           
        }

        public Candidate FindCandidate(string CID)
        {
            var o = _context.Candidates.Find(CID);
            return o;
        }

        public ICollection<Candidate> GetAllCandidate(string partyName)
        {
            var o = _context.Candidates.Where(x=>x.PartyName==partyName).ToList();
            return o;
        }

        public Candidate createCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);

            _context.SaveChanges();

            return _context.Candidates.Find(candidate.CID);
        }
    }
}
