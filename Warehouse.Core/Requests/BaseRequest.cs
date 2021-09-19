﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Core.Requests
{
    public class BaseRequest<TResponse> : IRequest<TResponse> where TResponse : BaseResponse
    {
    }
}
