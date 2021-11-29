using VotingAPI.Models;
using VotingAPI.Services.Models;

namespace VotingAPI.Services.Parties{
public interface IPartyRepository
    {
        public Party FindParty(string name);
        public List<Party> AllParty();

        public Party AddParty(Party party);

        //Update
        public void UpDateParty(PartyDto party);
        
    }
}