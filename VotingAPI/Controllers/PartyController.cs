using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Models;
using VotingAPI.Services.Models;
using VotingAPI.Services.Parties;
using AutoMapper;


namespace VotingAPI.Controllers
{
    [Route("api/party")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPartyRepository _service;
        public PartyController(IPartyRepository service)
        {
            _service=service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PartyDto>> AllParty()
        {
            var o = _service.AllParty();

            var mappedParty = _mapper.Map<ICollection<PartyDto>>(o);

            return Ok(mappedParty);
        }

        [HttpGet("{name}", Name="GetTModelById")]
        public ActionResult<PartyDto> GetTModelById(string name)
        {
            
            var o = _service.FindParty(name);

            var mappedParty = _mapper.Map<PartyDto>(o);

            return Ok(mappedParty);
        }

        [HttpPost]
        public ActionResult<PartyDto> PostTModel([FromBody]PartyDto party)
        {
            var mappedParty = _mapper.Map<Party>(party);

            var o = _service.AddParty(mappedParty);

            var partyForReturn = _mapper.Map<PartyDto>(o);

            return CreatedAtRoute("GetTModelById", new { name=partyForReturn.PartyName }, partyForReturn.PartyName);
        }

        [HttpPut]
        public IActionResult PutTModel(Party party)
        {

            var o = _service.UpDateParty(party);

            return Ok();
        }

        // [HttpDelete("{id}")]
        // public ActionResult<TModel> DeleteTModelById(int id)
        // {
        //     return null;
        // }
    }
}