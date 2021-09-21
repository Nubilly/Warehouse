using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Data.Stores;

namespace Warehouse.Core.Handlers.ManageProcessors
{
	public class MoveItemToBinHandler
	{
        private readonly IItemStore ItemStore;

        public MoveItemToBinHandler(IItemStore itemStore)
        {
            ItemStore = itemStore;
        }
    }
}
