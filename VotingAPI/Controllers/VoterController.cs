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
using Microsoft.AspNetCore.Authorization;
using VotingAPI.Services.Security;

namespace VotingAPI.Controllers
{
    [Authorize]
    [Route("api/voter")]
    [Controller]
    public class VoterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVoterRepository _voterRepository;
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;

        public VoterController(IMapper mapper,IVoterRepository voterRepository, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            
            _voterRepository = voterRepository;
            _mapper = mapper;
            _jwtAuthenticationManager = jWTAuthenticationManager;

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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = _jwtAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }


    }
}
