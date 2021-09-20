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

        public List<KeyValuePair<string, string>> Errors { get; set; } = new List<KeyValuePair<string, string>>();
    }
}
