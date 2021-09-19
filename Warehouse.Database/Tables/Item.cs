﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Database.Tables
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Key]
        public string Barcode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Location { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? LastUpdated { get; set; }
        public string? LastUpdatedBy { get; set; }
        [ForeignKey("Location")]
        public Bin? Bin { get; set; }
    }
}
