using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Requests.ManageBins;
using Warehouse.Data.Stores;

namespace Warehouse.Core.Handlers
{
    public class GetBinHandler : IRequestHandler<GetBinRequest, GetBinResponse>
    {
        private readonly IBinStore BinStore;

        public GetBinHandler(IBinStore binStore)
        {
            BinStore = binStore;
        }

        public async Task<GetBinResponse> Handle(GetBinRequest request, CancellationToken cancellationToken)
        {
            return new GetBinResponse
            {
                Bin = await BinStore.GetBin(request.Barcode, cancellationToken),
                ResponseCode = Requests.ResponseCode.Successful
            };
        }
    }
}
