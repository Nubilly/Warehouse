using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Data.Stores;

namespace Warehouse.Core.Handlers.ManageItems
{
	public class GetItemHandler
	{
        private readonly IItemStore ItemStore;

        public GetItemHandler(IItemStore itemStore)
        {
            ItemStore = itemStore;
        }
    }
}
