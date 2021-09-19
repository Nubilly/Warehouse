using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Common
{
    public class Pager
    {
        public string Filter { get; set; } = "";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 100;
    }
}
