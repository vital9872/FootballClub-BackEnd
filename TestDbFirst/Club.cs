using System;
using System.Collections.Generic;

#nullable disable

namespace TestDbFirst
{
    public partial class Club
    {
        public Club()
        {
            Matches = new HashSet<Match>();
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double Budget { get; set; }
        public int YearFounded { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
