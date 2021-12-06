using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.DataAccess;
using VotingAPI.Models;

namespace VotingAPI.Services.GramaNiladaris
{
    public class GramaNiladariSqlServices :IGramaNiladariRepository
    {
        private readonly VotingDbContext _context;
        public GramaNiladariSqlServices(VotingDbContext context)
        {
            _context = context;
        }

        public GramaNiladhari FindGramaNiladari(string GNID)
        {
            try
            {
                var a = _context.GramaNiladharis.Find(GNID);
                if (a == null)
                    return null;
                return a;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public ICollection<GramaNiladhari> GetAllGramaNiladari()
        {
            try
            {
                var a = _context.GramaNiladharis.ToList();
                return a;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public GramaNiladhari CreateGramaNildari(GramaNiladhari gramaNiladhari)
        {
            try
            {
                _context.GramaNiladharis.Add(gramaNiladhari);
                _context.SaveChanges();
                return _context.GramaNiladharis.Find(gramaNiladhari.GNID);
            }catch (Exception ex)
            {
                return null;
            }
        }
    }
}
