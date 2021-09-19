using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Requests.Bin;
using Warehouse.Data.Stores;

namespace Warehouse.Core.Handlers
{
    public class ListBinHandler : IRequestHandler<ListBinRequest, ListBinResponse>
    {
        private readonly IBinStore BinStore;

        public ListBinHandler(IBinStore binStore)
        {
            BinStore = binStore;
        }

        public async Task<ListBinResponse> Handle(ListBinRequest request, CancellationToken cancellationToken)
        {
            return new ListBinResponse
            {
                Bins = await BinStore.ListBins(request.Pager, cancellationToken),
                ResponseCode = Requests.ResponseCode.Successful
            };
        }
    }
}
