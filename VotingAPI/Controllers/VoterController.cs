using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingAPI.DataAccess;
using VotingAPI.Models;
using VotingAPI.Services.Voters;

namespace VotingAPI.Controllers
{
    [Route("api/voter")]
    [Controller]
    public class VoterController : Controller
    {
        private readonly VotingDbContext dbContext;
        private readonly IVoterRepository _voterRepository;

        public VoterController(VotingDbContext dbContext,IVoterRepository voterRepository)
        {
            this.dbContext = dbContext;
            this._voterRepository = voterRepository;
        }

        [HttpGet("{id}", Name ="GetVoters")]
        public IActionResult GetVoters(string id)
        {
            var b = _voterRepository.GetVoter(id);
            

            return Ok(b);
        }

        [HttpPost]
        public ActionResult CreateVoter([FromBody] Voter voter)
        {
            if (voter is null)
            {
                return NotFound();
            }
            var o = _voterRepository.createVoter(voter);

            return CreatedAtRoute("GetVoters", new { id = voter.VNIC }, o.VNIC);
        }
    }
}
