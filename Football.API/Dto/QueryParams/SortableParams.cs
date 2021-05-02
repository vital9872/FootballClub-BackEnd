using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Dto.QueryParams
{
    public class SortableParams
    {
        /// <summary>
        /// Property to be ordered by
        /// </summary>
        public string OrderByField { get; set; }
        /// <summary>
        /// Ascending or Descending sort
        /// </summary>
        public bool OrderByAscending { get; set; } = true;
    }
}
