using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common;

namespace Warehouse.Data.Stores
{
    public interface IItemStore
    {
        Task<bool> ItemBarcodeAvaliable(string barcode, CancellationToken cancellationToken = default);

        Task<PagedList<Common.Models.Item>> ListItems(Pager pager, CancellationToken cancellationToken = default);

        Task<Common.Models.Item> GetItem(string barcode, CancellationToken cancellationToken = default);

        Task AddItem(Common.Models.Item item, CancellationToken cancellationToken = default);

        Task UpdateItem(Common.Models.Item item, CancellationToken cancellationToken = default);

        Task RemoveItem(string barcode, CancellationToken cancellationToken = default);
    }
}
