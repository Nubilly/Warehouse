using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Core.Requests.ManageBins
{
    public class AddBinRequest : BaseRequest<AddBinResponse>
    {
        public Common.Models.Bin Bin { get; set; } = new Common.Models.Bin();
    }
}
