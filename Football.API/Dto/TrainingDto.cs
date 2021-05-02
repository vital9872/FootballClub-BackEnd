using Football.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Dto
{
    public class TrainingDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public TrainingType TrainingType { get; set; }
        public List<PlayerTrainingDto> PlayerTrainings { get; set; }
    }
}
