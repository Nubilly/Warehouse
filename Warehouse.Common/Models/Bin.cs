using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Common.Models
{
    public class Bin
    {
        public long Id { get; set; }     
        public string Barcode { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
