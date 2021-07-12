using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Shipper
    {
        [Column("ShipperId")]
        [Key]
        public int ShipperId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
