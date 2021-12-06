using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingAPI.Models;
using VotingAPI.Services.Models;
using VotingAPI.Services.Admins;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using VotingAPI.Services.Security;

namespace VotingAPI.Controllers
{
    [Authorize]
    [Route("api/admin")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminRepository _service;
        private readonly IMapper _mapper;
        private readonly IJWTAuthenticationManager _authenticationManager;
        public AdminController(IAdminRepository service, IMapper mapper, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _service = service;
            _mapper = mapper;
            _authenticationManager = jWTAuthenticationManager;
        }

        
        [HttpGet]
        public ActionResult<ICollection<AdminDto>> AllAdmin()
        {
            var a = _service.GetAllAdmin();

            var mappedAdmin = _mapper.Map<ICollection<AdminDto>>(a);

            return Ok(mappedAdmin);
        }

        
        [HttpGet("{adminID}",Name= "GetAdmin")]
        public ActionResult<AdminDto>  GetAdmin(string adminID)
        {
            var a = _service.FindAdmin(adminID);

            var mappedAdmin = _mapper.Map<AdminDto>(a);

            return Ok(mappedAdmin);
        }

        
        [HttpPost]
        public ActionResult<AdminDto> CreateAdmin(AdminDto admin)
        {
            var mappedAdmin = _mapper.Map<Admin>(admin);

            var a = _service.CreateAdmin(mappedAdmin);

            var adminReturn = _mapper.Map<AdminDto>(a);

            return CreatedAtRoute("GetAdmin", new { adminReturn.AdminID }, adminReturn.AdminID);
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
