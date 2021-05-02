using Football.API.Dto.QueryParams.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Dto.QueryParams
{
    public class FilterParameters
    {
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public FilterMethod Method { get; set; } = FilterMethod.Contains;
        public FilterOperand Operand { get; set; } = FilterOperand.Or;
    }
}
