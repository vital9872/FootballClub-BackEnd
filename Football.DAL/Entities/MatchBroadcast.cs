using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DAL.Entities
{
    public class MatchBroadcast:IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MatchTournamentId { get; set; }
        public MatchTournament MatchTournament { get; set; }
        public double Payment { get; set; }
    }
}
