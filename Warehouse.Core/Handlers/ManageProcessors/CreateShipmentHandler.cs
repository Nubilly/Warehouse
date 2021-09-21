using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Data.Stores;

namespace Warehouse.Core.Handlers.ManageProcessors
{
	public class CreateShipmentHandler
	{
        private readonly IItemStore ItemStore;

        public CreateShipmentHandler(IItemStore itemStore)
        {
            ItemStore = itemStore;
        }
    }
}
