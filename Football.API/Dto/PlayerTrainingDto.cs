using Football.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Dto
{
    public class PlayerTrainingDto
    {
        public int TrainingId { get; set; }
        public PlayerDto Player { get; set; }
        public int Shooting { get; set; }
        public int Speed { get; set; }
        public int Dribling { get; set; }
        public int Defensive { get; set; }
    }
}
