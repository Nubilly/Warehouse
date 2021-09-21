using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Core.Requests.ManageItems
{
	public class AddItemRequest : BaseRequest<AddItemResponse>
	{
		public Common.Models.Item Item { get; set; } = new Common.Models.Item();
	}
}
