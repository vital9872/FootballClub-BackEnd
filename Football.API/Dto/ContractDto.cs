using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.ViewModels
{
    public class ContractDto
    {
        public int Id { get; set; }
        public double Salary { get; set; }
        public double Premium { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public double Price { get; set; }
    }
}
