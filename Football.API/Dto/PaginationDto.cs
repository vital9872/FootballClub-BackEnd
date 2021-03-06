using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Dto
{
    public class PaginationDto<T> where T : class
    {
        public List<T> Page { get; set; }
        public int? TotalCount { get; set; }
    }
}
