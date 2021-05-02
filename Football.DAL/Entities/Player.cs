using System;
using System.Collections.Generic;

namespace Football.DAL.Entities
{
    public class Player:IEntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }
        public DateTime Birth { get; set; }
        public bool IsCaptain { get; set; }
        public int? ContractId { get; set; }
        public PlayerContract Contract { get; set; }
        public List<PlayerMatch> PlayerMatches { get; set; }
        public List<PlayerTraining> PlayerTrainings { get; set; }
    }
}
