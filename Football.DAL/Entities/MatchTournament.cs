using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DAL.Entities
{
    public class MatchTournament:IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DefaultPayment { get; set; }
    }
}
