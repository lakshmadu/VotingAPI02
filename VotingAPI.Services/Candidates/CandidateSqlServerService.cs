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
            try
            {
                var o = _context.Candidates.Find(CID);
                if (o == null)
                    return null;
                return o;
            }catch (Exception ex)
            {
                return null;
            }
            
        }

        public ICollection<Candidate> GetAllCandidate(string partyName)
        {
            try
            {
                var o =  _context.Candidates.Where(x => x.PName == partyName).ToList();

                return o;
            }catch(Exception ex)
            {
                return null;
            }
            
        }

        public Candidate createCandidate(Candidate candidate)
        {
            try
            {
                _context.Candidates.Add(candidate);

                _context.SaveChanges();

                return  _context.Candidates.Find(candidate.CID);
            }catch (Exception ex)
            {
                return null;
            }
           
        }
    }
}
