using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Dto.QueryParams
{
    public class FullPaginationQueryParams : PageableParams
    {
        public FilterParameters[] Filters { get; set; }
        public SortableParams Sort { get; set; }
    }
}
