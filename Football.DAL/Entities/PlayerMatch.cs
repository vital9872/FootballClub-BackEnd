using System;

namespace Football.DAL.Entities
{
    public class PlayerMatch:IEntityBase
    {
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int? PlayerId { get; set; }
        public Player Player { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
    }
}
