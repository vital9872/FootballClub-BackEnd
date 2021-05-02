using System;
using System.Collections.Generic;

#nullable disable

namespace TestDbFirst
{
    public partial class Player
    {
        public Player()
        {
            PlayerMatches = new HashSet<PlayerMatch>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime Birth { get; set; }
        public bool IsCaptain { get; set; }
        public int? ClubId { get; set; }
        public int? ContractId { get; set; }

        public virtual Club Club { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual ICollection<PlayerMatch> PlayerMatches { get; set; }
    }
}
