using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Core.Requests.ManageItems
{
	public class RemoveItemRequest : BaseRequest<RemoveItemResponse>
	{
		public string Barcode { get; set; } = "";
	}
}
