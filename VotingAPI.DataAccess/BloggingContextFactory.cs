using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.DataAccess
{
    class BloggingContextFactory : IDesignTimeDbContextFactory<VotingDbContext>
    {
        
        public VotingDbContext CreateDbContext(string[] args)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<VotingDbContext>();
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=VotingDB;Trusted_Connection=True;MultipleActiveResultSets=True;");

            return new VotingDbContext(optionsBuilder.Options);
        }
    }
}
