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
    public class AddBinHandler : IRequestHandler<AddBinRequest, AddBinResponse>
    {
        private readonly IBinStore BinStore;

        public AddBinHandler(IBinStore binStore)
        {
            BinStore = binStore;
        }

        public async Task<AddBinResponse> Handle(AddBinRequest request, CancellationToken cancellationToken)
        {
            await BinStore.AddBin(request.Bin, cancellationToken);

            return new AddBinResponse
            {                
                ResponseCode = Requests.ResponseCode.Successful
            };
        }
    }
}
