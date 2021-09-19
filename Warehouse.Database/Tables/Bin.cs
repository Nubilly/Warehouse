using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Database.Tables
{
    public class Bin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Key]
        public string Barcode { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;


        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
