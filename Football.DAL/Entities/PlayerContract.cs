using System;

namespace Football.DAL.Entities
{
    public class PlayerContract:IEntityBase
    {
        public int Id { get; set; }
        //public Player Player{ get; set; }
        public double Salary { get; set; }
        public double Premium { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public double Price { get; set; }
    }
}
