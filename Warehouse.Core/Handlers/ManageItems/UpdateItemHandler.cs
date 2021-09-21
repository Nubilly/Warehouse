using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Data.Stores;

namespace Warehouse.Core.Handlers.ManageItems
{
	public class UpdateItemHandler
	{
        private readonly IItemStore ItemStore;

        public UpdateItemHandler(IItemStore itemStore)
        {
            ItemStore = itemStore;
        }
    }
}
