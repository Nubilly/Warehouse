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
    public class RemoveBinHandler : IRequestHandler<RemoveBinRequest, RemoveBinResponse>
    {
        private readonly IBinStore BinStore;

        public RemoveBinHandler(IBinStore binStore)
        {
            BinStore = binStore;
        }

		public Task<RemoveBinResponse> Handle(RemoveBinRequest request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
