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
    public class PartyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPartyRepository _service;
        public PartyController(IPartyRepository service,IMapper mapper)
        {
            _service=service;
            _mapper = mapper;
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
        public ActionResult<PartyDto> CreateParty([FromForm]PartyDto party,IFormFile formFile)
        {
            

            
            
                if(formFile.Length > 0)
                {
                    using(var stram = new MemoryStream())
                    {
                        formFile.CopyTo(stram);
                        party.Image = stram.ToArray();
                    }
                }
            
            var mappedParty = _mapper.Map<Party>(party);

            var o = _service.AddParty(mappedParty);

            var partyForReturn = _mapper.Map<PartyDto>(o);

            return CreatedAtRoute("GetTModelById", new { name=partyForReturn.PName }, partyForReturn.PName);
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