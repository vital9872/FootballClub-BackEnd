using System;
using System.Collections.Generic;

namespace Football.DAL.Entities
{
    public class Match :IEntityBase
    {
        public int Id { get; set; }
        public MatchLocation MatchLocation { get; set; }
        public int? MatchTournamentId { get; set; }
        public MatchTournament MatchTournament { get; set; }
        public DateTime StartDate { get; set; }
        public string ClubEnemyName { get; set; }
        public List<PlayerMatch> PlayerMatches { get; set; }
        public double? TicketSales { get; set; }
        public double Outcome { get; set; }
        public int Team1Goals { get; set; }
        public int Team2Goals { get; set; }
    }
}
