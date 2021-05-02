using AutoMapper;
using Football.API.Dto;
using Football.DAL.Entities;


namespace Football.API.Profiles
{
    public class MatchBroadcastProfile : Profile
    {
        public MatchBroadcastProfile()
        {
            CreateMap<MatchBroadcast, MatchBroadcastDto>()
                .ForMember(dto => dto.MatchTournamentId, e => e.MapFrom(x => x.MatchTournamentId))
                .ForMember(dto => dto.MatchTournamentName, e => e.MapFrom(x => x.MatchTournament.Name))
                .ForMember(dto => dto.DefaultPayment, e => e.MapFrom(x => x.MatchTournament.DefaultPayment));

            CreateMap<MatchBroadcastDto, MatchBroadcast>();
        }
    }
}
