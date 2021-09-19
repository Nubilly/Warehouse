using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Core.Requests.Bin
{
    public class UpdateBinRequest : BaseRequest<UpdateBinResponse>
    {
        public Common.Models.Bin Bin { get; set; } = new Common.Models.Bin();
    }
}
