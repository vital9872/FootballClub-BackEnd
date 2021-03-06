using AutoMapper;
using Football.API.Dto;
using Football.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Profiles
{
    public class PlayerTrainingProfile : Profile
    {
        public PlayerTrainingProfile()
        {
            CreateMap<PlayerTraining, PlayerTrainingDto>().ReverseMap();
        }
    }
}
