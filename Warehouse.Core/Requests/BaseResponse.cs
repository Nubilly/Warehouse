using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Core.Requests
{
    public class BaseResponse
    {
        public ResponseCode ResponseCode { get; set; } = ResponseCode.Error;
    }
}
