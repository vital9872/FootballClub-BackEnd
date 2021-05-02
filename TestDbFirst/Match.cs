using System;
using System.Collections.Generic;

#nullable disable

namespace TestDbFirst
{
    public partial class Match
    {
        public Match()
        {
            PlayerMatches = new HashSet<PlayerMatch>();
        }

        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public int? ClubId { get; set; }
        public string ClubEnemyName { get; set; }
        public int Team1Goals { get; set; }
        public int Team2Goals { get; set; }

        public virtual Club Club { get; set; }
        public virtual ICollection<PlayerMatch> PlayerMatches { get; set; }
    }
}
