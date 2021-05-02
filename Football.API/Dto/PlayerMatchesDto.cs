using Football.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Dto
{
    public class PlayerMatchesDto
    {
        public int MatchId { get; set; }
        public PlayerDto Player { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
    }
}
