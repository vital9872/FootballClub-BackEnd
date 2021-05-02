using System;
using System.Collections.Generic;

#nullable disable

namespace TestDbFirst
{
    public partial class Contract
    {
        public int Id { get; set; }
        public double Salary { get; set; }
        public double Premium { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public double Price { get; set; }

        public virtual Player Player { get; set; }
    }
}
