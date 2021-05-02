using Football.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.ViewModels
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }
        public DateTime Birth { get; set; }
        public bool IsCaptain { get; set; }
        public int? Club_Id { get; set; }
        public ContractDto Contract { get; set; }
    }
}
