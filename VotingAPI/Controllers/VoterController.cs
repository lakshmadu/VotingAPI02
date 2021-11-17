using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingAPI.DataAccess;
using VotingAPI.Models;
using VotingAPI.Services.Voters;
using VotingAPI.Services.Models;

namespace VotingAPI.Controllers
{
    [Route("api/voter")]
    [Controller]
    public class VoterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVoterRepository _voterRepository;

        public VoterController(VotingDbContext dbContext,IVoterRepository voterRepository)
        {
            
            this._voterRepository = voterRepository;
        }

        [HttpGet("{id}", Name ="GetVoters")]
        public ActionResult<VoterDto> GetVoters(string id)
        {

            var b = _voterRepository.GetVoter(id);

            var mappedVoter = _mapper.Map<VoterDto>(b);            

            return Ok(mappedVoter);
        }

        [HttpPost]
        public ActionResult<VoterDto> CreateVoter([FromBody] VoterDto voter)
        {
            var mappedVoter = _mapper.Map<Voter>(voter);

            if (mappedVoter is null)
            {
                return NotFound();
            }

            var o = _voterRepository.createVoter(mappedVoter);

            var voterForReturn = _mapper.Map<VoterDto>(o);

            return CreatedAtRoute("GetVoters", new { id = voterForReturn.VNIC }, voterForReturn);
        }


    }
}
