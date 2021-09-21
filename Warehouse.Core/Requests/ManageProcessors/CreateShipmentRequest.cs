using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common.Models;

namespace Warehouse.Core.Requests.ManageProcessors
{
	public class CreateShipmentRequest : BaseRequest<CreateShipmentResponse>
	{
		public Shipment	Shipment { get; set; } = new Shipment();
	}
}
