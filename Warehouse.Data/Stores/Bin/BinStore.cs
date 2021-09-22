using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common;
using Warehouse.Data.Extensions;
using Warehouse.Database;

namespace Warehouse.Data.Stores
{
    public class BinStore : IBinStore
    {
        private readonly WarehouseContext WarehouseContext;

        public BinStore(WarehouseContext warehouseContext)
        {
            WarehouseContext = warehouseContext;
        }
        public async Task AddBin(Common.Models.Bin bin, CancellationToken cancellationToken = default)
        {
            await WarehouseContext.AddAsync(new Database.Tables.Bin { Barcode = bin.Barcode, Label = bin.Label, Location = bin.Location }, cancellationToken);
            await WarehouseContext.SaveChangesAsync();
        }

		public async Task<bool> BinBarcodeAvaliable(string barcode, CancellationToken cancellationToken = default)
		{
            return await WarehouseContext.Set<Database.Tables.Bin>().AsNoTracking().AllAsync(x => x.Barcode != barcode, cancellationToken);
		}

		public async Task<Common.Models.Bin> GetBin(string barcode, CancellationToken cancellationToken = default)
        {
            var bin = await WarehouseContext.Set<Database.Tables.Bin>().AsNoTracking().FirstOrDefaultAsync(x => x.Barcode == barcode, cancellationToken);

            if (bin == null)
                throw new ArgumentNullException(nameof(bin));

            return new Common.Models.Bin
            {
                Id = bin.Id,
                Barcode = bin.Barcode,
                Label = bin.Label,
                Location = bin.Location,
            };
        }

        public async Task<PagedList<Common.Models.Bin>> ListBins(Pager pager, CancellationToken cancellationToken = default)
        {
            Expression<Func<Database.Tables.Bin, bool>> condition = x =>
                      x.Barcode.Contains(pager.Filter)
                   || x.Label.Contains(pager.Filter);

            var query = WarehouseContext.Set<Database.Tables.Bin>().AsNoTracking().WhereIf(!string.IsNullOrEmpty(pager.Filter), condition);

            var bins = await query.PageBy(x => x.Label, pager).Select(x => new Common.Models.Bin { Id = x.Id, Barcode = x.Barcode, Label = x.Label, Location = x.Location }).ToListAsync(cancellationToken);

            var binsCount = await query.CountAsync(cancellationToken);

            return new PagedList<Common.Models.Bin>
            {
                Items = bins,
                PageSize = pager.PageSize,
                TotalCount = binsCount,
            };
        }

        public async Task RemoveBin(string barcode, CancellationToken cancellationToken = default)
        {
            var bin = await WarehouseContext.Set<Database.Tables.Bin>().FirstOrDefaultAsync(x => x.Barcode == barcode, cancellationToken);

            if (bin == null)
                throw new ArgumentNullException(nameof(bin));

            WarehouseContext.Remove(bin);

            await WarehouseContext.SaveChangesAsync();
        }

        public async Task UpdateBin(Common.Models.Bin bin, CancellationToken cancellationToken = default)
        {
            var oldbin = await WarehouseContext.Set<Database.Tables.Bin>().FirstOrDefaultAsync(x => x.Barcode == bin.Barcode, cancellationToken);

            if (oldbin == null)
                throw new ArgumentNullException(nameof(bin));

            oldbin.Label = bin.Label;
            oldbin.Location = bin.Location;

            await WarehouseContext.SaveChangesAsync();
        }
    }
}
