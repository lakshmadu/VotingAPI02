using VotingAPI.Models;

namespace VotingAPI.Services.Parties{
public interface IPartyRepository
    {
        public Party FindParty(string name);
        public Party AllParty();

        public Party AddParty(Party party);

        //Update
        public Party UpDateParty(Party party);
        
    }
}