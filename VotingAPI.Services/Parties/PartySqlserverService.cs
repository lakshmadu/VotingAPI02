using VotingAPI.Models;
using VotingAPI.DataAccess;
using Microsoft.EntityFrameworkCore;

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
            var o = _contex.Parties.Find(name);

            return o;
        }
        public Party AllParty(){
            var o = _contex.Parties.Find();//error
            return o;
        }

        public Party AddParty(Party party)
        {
            _contex.Parties.Add(party);

            _contex.SaveChanges();

            return _contex.Parties.Find(party.PartyName);

            
        }
        public Party UpDateParty(Party party)
        {

            _contex.Entry(party).State = EntityState.Modified;
            _contex.SaveChanges();
            return _contex.Parties.Find(party.PartyName);
        }


    }
}

