using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Common.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public string Reference { get; set; } = "";
        public List<ShipmentItem> Items { get; set; } = new List<ShipmentItem>();
    }
}
