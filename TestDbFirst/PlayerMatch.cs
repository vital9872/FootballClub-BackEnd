using System;
using System.Collections.Generic;

#nullable disable

namespace TestDbFirst
{
    public partial class PlayerMatch
    {
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }

        public virtual Match Match { get; set; }
        public virtual Player Player { get; set; }
    }
}
