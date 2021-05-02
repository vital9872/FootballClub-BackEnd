using AutoMapper;
using Football.API.ViewModels;
using Football.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDto>().ReverseMap();

            CreateMap<Player, PlayerGetDto>()
                .ForMember(vm => vm.Goals, e => e.MapFrom(x => x.PlayerMatches.Sum(g => g.Goals)))
                .ForMember(vm => vm.Assists, e => e.MapFrom(x => x.PlayerMatches.Sum(g => g.Assists)));
        }
    }
}
