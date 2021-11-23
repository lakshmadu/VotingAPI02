using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VotingAPI.Models;
using VotingAPI.Services.Models;

namespace VotingAPI.Services.Profiles
{
    public class VoterProfile : Profile
    {
        public VoterProfile()
        {
            CreateMap<Voter, VoterDto>();
            CreateMap<VoterDto, Voter>();
        }
    }
}
