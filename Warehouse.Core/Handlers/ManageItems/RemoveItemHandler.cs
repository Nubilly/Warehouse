using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Data.Stores;

namespace Warehouse.Core.Handlers.ManageItems
{
	public class RemoveItemHandler
	{
        private readonly IItemStore ItemStore;

        public RemoveItemHandler(IItemStore itemStore)
        {
            ItemStore = itemStore;
        }
    }
}
