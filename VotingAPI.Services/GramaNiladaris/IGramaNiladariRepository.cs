using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Models;

namespace VotingAPI.Services.GramaNiladaris
{
    public interface IGramaNiladariRepository
    {
        public GramaNiladhari FindGramaNiladari(string GNID);

        public ICollection<GramaNiladhari> GetAllGramaNiladari();

        public GramaNiladhari CreateGramaNildari(GramaNiladhari gramaNiladhari);
    }
}
