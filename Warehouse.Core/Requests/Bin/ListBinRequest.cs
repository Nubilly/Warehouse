using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common;

namespace Warehouse.Core.Requests.Bin
{
    public class ListBinRequest : BaseRequest<ListBinResponse>
    {
        public Pager Pager { get; set; } = new Pager();
    }
}
