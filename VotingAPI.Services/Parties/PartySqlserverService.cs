using VotingAPI.Models;
using VotingAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using VotingAPI.Services.Models;

namespace VotingAPI.Services.Parties
{
    
    
    public class PartySqlserverService : IPartyRepository
    {
        private readonly VotingDbContext _contex;
        public PartySqlserverService(VotingDbContext context)
        {
            _contex=context;
        }

        public Party FindParty(string name)
        {
            try
            {
                var o = _contex.Parties.Find(name);

                return o;
            }catch (Exception ex)
            {
                return null;
            }
            
        }
        public List<Party> AllParty(){
            try
            {
                var o = _contex.Parties.ToList();

                return o;
            }catch(Exception ex)
            {
                return null;
            }
            
        }

        public Party AddParty(Party party)
        {
            try
            {
                _contex.Parties.Add(party);

                _contex.SaveChanges();

                return _contex.Parties.Find(party.PName);

            }catch(Exception ex)
            {
                return null;
            }
            

            
        }
        public void UpDateParty(PartyDto party)
        {

            try
            {
                _contex.SaveChanges();
            }catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);   
            }
            
            //return _contex.Parties.Find(party.PName);
        }


    }
}

