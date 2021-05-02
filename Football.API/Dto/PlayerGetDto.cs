using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.ViewModels
{
    public class PlayerGetDto : PlayerDto
    {
        public int Goals { get; set; }
        public int Assists { get; set; }
    }
}
