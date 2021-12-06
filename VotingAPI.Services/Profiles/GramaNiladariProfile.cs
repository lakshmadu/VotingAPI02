using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Models;
using VotingAPI.Services.Models;

namespace VotingAPI.Services.Profiles
{
    public class GramaNiladariProfile : Profile
    {
        public GramaNiladariProfile()
        {
            CreateMap<GramaNiladhari, GramaNiladariDto>();
            CreateMap<GramaNiladariDto, GramaNiladhari>();
        }
    }
}
