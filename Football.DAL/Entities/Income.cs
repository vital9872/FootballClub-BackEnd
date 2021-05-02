using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DAL.Entities
{
    public class Income: IEntityBase
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
