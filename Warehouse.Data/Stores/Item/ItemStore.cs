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
    public class ItemStore : IItemStore
    {
        private readonly WarehouseContext WarehouseContext;

        public ItemStore(WarehouseContext warehouseContext)
        {
            WarehouseContext = warehouseContext;
        }

        public async Task AddItem(Common.Models.Item item, CancellationToken cancellationToken = default)
        {
            await WarehouseContext.AddAsync(new Database.Tables.Item { Barcode = item.Barcode, Description = item.Description, Location = item.Location, Quantity = item.Quantity }, cancellationToken);
            await WarehouseContext.SaveChangesAsync();
        }

        public async Task<Common.Models.Item> GetItem(string barcode, CancellationToken cancellationToken = default)
        {
            var bin = await WarehouseContext.Set<Database.Tables.Item>().AsNoTracking().FirstOrDefaultAsync(x => x.Barcode == barcode, cancellationToken);

            if (bin == null)
                throw new ArgumentNullException(nameof(bin));

            return new Common.Models.Item
            {
                Id = bin.Id,
                Barcode = bin.Barcode,
                Description = bin.Description,
                Location = bin.Location,
                Quantity = bin.Quantity,
            };
        }

        public async Task<PagedList<Common.Models.Item>> ListItems(Pager pager, CancellationToken cancellationToken = default)
        {
            Expression<Func<Database.Tables.Item, bool>> condition = x =>
                     x.Barcode.Contains(pager.Filter)
                  || x.Name.ToString().Contains(pager.Filter);

            var query = WarehouseContext.Set<Database.Tables.Item>().AsNoTracking().WhereIf(!string.IsNullOrEmpty(pager.Filter), condition);

            var items = await query.PageBy(x => x.Description, pager).Select(x => new Common.Models.Item { Id = x.Id, Barcode = x.Barcode, Description = x.Description, Quantity = x.Quantity, Location = x.Location }).ToListAsync(cancellationToken);

            var itemsCount = await query.CountAsync(cancellationToken);

            return new PagedList<Common.Models.Item>
            {
                Items = items,
                PageSize = pager.PageSize,
                TotalCount = itemsCount,
            };
        }

        public async Task RemoveItem(string barcode, CancellationToken cancellationToken = default)
        {
            var item = await WarehouseContext.Set<Database.Tables.Item>().FirstOrDefaultAsync(x => x.Barcode == barcode, cancellationToken);

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            WarehouseContext.Remove(item);

            await WarehouseContext.SaveChangesAsync();
        }

        public async Task UpdateItem(Common.Models.Item item, CancellationToken cancellationToken = default)
        {
            var oldItem = await WarehouseContext.Set<Database.Tables.Item>().FirstOrDefaultAsync(x => x.Barcode == item.Barcode, cancellationToken);

            if (oldItem == null)
                throw new ArgumentNullException(nameof(oldItem));

            oldItem.Name = item.Name;
            oldItem.Description = item.Description;
            oldItem.Location = item.Location;
            oldItem.Quantity = item.Quantity;

            await WarehouseContext.SaveChangesAsync();
        }
    }
}
