using Football.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Dto
{
    public class MatchBroadcastDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MatchTournamentId { get; set; }
        public string MatchTournamentName { get; set; }
        public double DefaultPayment { get; set; }
        public double Payment { get; set; }
    }
}
