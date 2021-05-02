using AutoMapper;
using Football.API.Dto;
using Football.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Profiles
{
    public class PlayerMatchProfile: Profile
    {
        public PlayerMatchProfile()
        {
            CreateMap<PlayerMatch, PlayerMatchesDto>().ReverseMap();
        }
    }
}
