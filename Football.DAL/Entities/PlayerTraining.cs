using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DAL.Entities
{
    public class PlayerTraining : IEntityBase
    {
        public int TrainingId { get; set; }
        public Training Training { get; set; }
        public int? PlayerId { get; set; }
        public Player Player { get; set; }
        public int Shooting { get; set; }
        public int Speed { get; set; }
        public int Dribling { get; set; }
        public int Defensive { get; set; }
    }
}
