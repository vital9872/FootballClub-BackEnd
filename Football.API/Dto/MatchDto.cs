using Football.API.Dto;
using Football.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.ViewModels
{
    public class MatchDto
    {
        public int Id { get; set; }
        public MatchLocation MatchLocation { get; set; }
        public MatchTournament MatchTournament { get; set; }
        public DateTime StartDate { get; set; }
        public string ClubEnemyName { get; set; }
        public List<PlayerMatchesDto> PlayerMatches { get; set; }
        public double? TicketSales { get; set; }
        public double Outcome { get; set; }
        public int Team1Goals { get; set; }
        public int Team2Goals { get; set; }
    }
}
