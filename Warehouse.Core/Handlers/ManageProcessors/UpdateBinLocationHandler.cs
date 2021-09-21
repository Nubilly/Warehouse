using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Data.Stores;

namespace Warehouse.Core.Handlers.ManageProcessors
{
	public class UpdateBinLocationHandler
	{
        private readonly IItemStore ItemStore;

        public UpdateBinLocationHandler(IItemStore itemStore)
        {
            ItemStore = itemStore;
        }
    }
}
