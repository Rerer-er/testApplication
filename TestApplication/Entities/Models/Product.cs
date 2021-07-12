using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Product
    {
        [Column("ProductId")]
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        [ForeignKey(nameof(Kind))]
        public int KindId { get; set; }
        public Kind Kind { get; set; }

        [ForeignKey(nameof(Shipper))]
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }

    }
}
