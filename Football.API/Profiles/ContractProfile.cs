using AutoMapper;
using Football.API.ViewModels;
using Football.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Profiles
{
    public class ContractProfile:Profile
    {
        public ContractProfile()
        {
            CreateMap<PlayerContract, ContractDto>().ReverseMap();
        }
    }
}
