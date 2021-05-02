using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DAL.Entities
{
    public class Training : IEntityBase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public TrainingType TrainingType { get; set; }
        public List<PlayerTraining> PlayerTrainings { get; set; }
    }
}
