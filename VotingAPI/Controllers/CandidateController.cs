using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingAPI.Models;
using VotingAPI.Services.Candidates;
using AutoMapper;
using VotingAPI.Services.Models;


namespace VotingAPI.Controllers
{

    [Route("api/candidate")]
    [ApiController]
    public class CandidateController : Controller
    {
        private readonly ICandidateRepository _service;
        private readonly IMapper _mapper;
        
        public CandidateController(ICandidateRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<CandidateDto>> AllCandidate(string partyName)
        {
            var o = _service.GetAllCandidate(partyName);

            var mappedCandidate = _mapper.Map<ICollection<CandidateDto>>(o);

            return Ok(mappedCandidate);

        }
        [HttpGet ("{CID}",Name= "GetCandidateById")]
        public ActionResult<CandidateDto> GetCandidateById(string CID)
        {
            var o = _service.FindCandidate(CID);

            var mappedCandidate = _mapper.Map<CandidateDto>(o);

            return Ok(mappedCandidate);
        }
        [HttpPost]
        public ActionResult<CandidateDto> CreateCandidate([FromBody]CandidateDto candidateDto)
        {
            var mappedCandidate = _mapper.Map<Candidate>(candidateDto);

            var o = _service.createCandidate(mappedCandidate);

            var candidateForReturn = _mapper.Map<CandidateDto>(o);

            return CreatedAtRoute("GetCandidateById", new { candidateForReturn.CID }, candidateForReturn.CID);
            //return Ok(candidateForReturn.CID);



        }

    }
}
