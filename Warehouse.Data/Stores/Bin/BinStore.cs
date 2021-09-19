using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common;

namespace Warehouse.Data.Stores.Bin
{
    public class BinStore : IBinStore
    {
        public Task AddBin(Common.Models.Bin bin, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Common.Models.Bin> GetBin(string barcode, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<Common.Models.Bin>> ListBins(Pager pager, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task RemoveBin(string barcode, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBin(Common.Models.Bin bin, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
