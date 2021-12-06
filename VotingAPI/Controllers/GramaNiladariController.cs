using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingAPI.Models;
using VotingAPI.Services.Models;
using VotingAPI.Services.GramaNiladaris;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using VotingAPI.Services.Security;

namespace VotingAPI.Controllers
{
    [Authorize]
    [Route("api/gramaniladhari")]
    [ApiController]
    public class GramaNiladariController : Controller
    {
        public readonly IGramaNiladariRepository _services;
        private readonly IMapper _mapper;
        private readonly IJWTAuthenticationManager _authenticationManager;
        public GramaNiladariController(IGramaNiladariRepository services, IMapper mapper, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _services = services;
            _mapper = mapper;
            _authenticationManager = jWTAuthenticationManager;
        }


        [HttpGet]
        public ActionResult<ICollection<GramaNiladariDto>> AllGramaNiladari()
        {
            var a = _services.GetAllGramaNiladari();

            var mappedGramaNiladhari = _mapper.Map<ICollection<GramaNiladariDto>>(a);

            return Ok(mappedGramaNiladhari);
        }

        [HttpGet("{gNID}", Name = "GetGramaNiladari")]
        public ActionResult<GramaNiladariDto> GetGramaNiladari(string gNID)
        {
            var a = _services.FindGramaNiladari(gNID);

            var mappedGramaNiladhari = _mapper.Map<GramaNiladariDto>(a);

            return Ok( mappedGramaNiladhari);
        }

        [HttpPost]
        public ActionResult<GramaNiladariDto> CreateGramaNiladari(GramaNiladariDto gramaniladari)
        {
            var mappedGramaNiladhari = _mapper.Map<GramaNiladhari>(gramaniladari); ;

            var a = _services.CreateGramaNildari(mappedGramaNiladhari);

            var GramaNiladhariReturn = _mapper.Map<GramaNiladariDto>(a);

            return CreatedAtRoute("GetGramaNiladari", new { GramaNiladhariReturn.GNID }, GramaNiladhariReturn.GNID);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = _authenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}
