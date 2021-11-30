using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.DataAccess;
using VotingAPI.Models;

namespace VotingAPI.Services.Voters
{
    public class VoterSqlServerService : IVoterRepository
    {
        private readonly VotingDbContext _dbContext;

        public VoterSqlServerService(VotingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Voter GetVoter(string id)
        {
            try
            {
                var o = _dbContext.Voters.Find(id);

                return o;
            }catch(Exception ex){
                return null;
            }
            
            
        }

        public Voter createVoter(Voter voter)
        {
            try
            {

                var o = _dbContext.Voters.Add(voter);

                _dbContext.SaveChanges();

                return _dbContext.Voters.Find(voter.VNIC);
            }
            catch (Exception ex)
            {
                return null;
            }

            
            
        }


    }
}
