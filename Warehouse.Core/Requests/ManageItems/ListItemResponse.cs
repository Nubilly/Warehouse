using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common;

namespace Warehouse.Core.Requests.ManageItems
{
	public class ListItemResponse : BaseResponse
	{
		public PagedList<Common.Models.Item> Bins { get; set; } = new PagedList<Common.Models.Item>();
	}
}
