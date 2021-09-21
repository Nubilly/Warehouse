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

		public Task<UpdateBinResponse> Handle(UpdateBinRequest request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
