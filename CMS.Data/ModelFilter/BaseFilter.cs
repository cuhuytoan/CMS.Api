using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.ModelFilter
{
    internal class BaseFilter
    {
    }
    public class Filter
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public object Value { get; set; }
        public string Logic { get; set; }
        public IEnumerable<Filter> Filters { get; set; }
    }

    public class Sort
    {
        public string Field { get; set; }
        public string Dir { get; set; }
    }

    public class FilterDTO
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<Sort> Sort { get; set; }
        public Filter Filter { get; set; }
    }
}
