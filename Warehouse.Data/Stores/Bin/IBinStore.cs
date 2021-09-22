using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common;

namespace Warehouse.Data.Stores
{
    public interface IBinStore
    {
        Task<bool> BinBarcodeAvaliable(string barcode, CancellationToken cancellationToken = default);

        Task<PagedList<Common.Models.Bin>> ListBins(Pager pager, CancellationToken cancellationToken = default);

        Task<Common.Models.Bin> GetBin(string barcode, CancellationToken cancellationToken = default);

        Task AddBin(Common.Models.Bin bin, CancellationToken cancellationToken = default);

        Task UpdateBin(Common.Models.Bin bin, CancellationToken cancellationToken = default);

        Task RemoveBin(string barcode, CancellationToken cancellationToken = default);
    }
}
