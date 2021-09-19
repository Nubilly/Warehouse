using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common;

namespace Warehouse.Data.Stores
{
    public class ItemStore : IItemStore
    {
        public Task AddItem(Common.Models.Item item, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Common.Models.Item> GetItem(string barcode, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<Common.Models.Item>> ListItems(Pager pager, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItem(string barcode, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItem(Common.Models.Item item, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
