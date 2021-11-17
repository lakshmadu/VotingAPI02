using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Services.Models;
using VotingAPI.Models;
using AutoMapper;

namespace VotingAPI.Services.Profiles
{

    public class PartyProfile : Profile
    {
        public PartyProfile()
        {
            CreateMap<Party, PartyDto>();
            CreateMap<PartyDto, Party>();
        }

    }
}
