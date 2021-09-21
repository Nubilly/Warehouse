using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Core.Requests.ManageBins
{
    public class RemoveBinRequest : BaseRequest<RemoveBinResponse>
    {
        public string Barcode { get; set; } = "";
    }
}
