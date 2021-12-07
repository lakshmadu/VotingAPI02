using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingAPI.Controllers
{
    [Route("api/values")]
    [Controller]
    public class ValueController : Controller
    {
        [HttpGet]
        public  IEnumerable<string> Get()
        {
            return new string[] { "Value01", "Value02","Lakshan Madhubashika","Ahamed Rashad","Waruni Imalsha" };
        }

        
    }
}
