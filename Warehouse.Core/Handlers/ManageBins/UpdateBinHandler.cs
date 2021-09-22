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
    public class UpdateBinHandler : IRequestHandler<UpdateBinRequest, UpdateBinResponse>
    {
        private readonly IBinStore BinStore;

        public UpdateBinHandler(IBinStore binStore)
        {
            BinStore = binStore;
        }

		public async Task<UpdateBinResponse> Handle(UpdateBinRequest request, CancellationToken cancellationToken)
		{
            await BinStore.UpdateBin(request.Bin, cancellationToken);

            return new UpdateBinResponse
            {
                ResponseCode = Requests.ResponseCode.Successful
            };
        }
	}
}
