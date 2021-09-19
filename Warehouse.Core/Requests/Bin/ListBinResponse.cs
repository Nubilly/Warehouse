using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common;

namespace Warehouse.Core.Requests.Bin
{
    public class ListBinResponse : BaseResponse
    {
        public PagedList<Common.Models.Bin> Bins { get; set; } = new PagedList<Common.Models.Bin>();
    }
}
