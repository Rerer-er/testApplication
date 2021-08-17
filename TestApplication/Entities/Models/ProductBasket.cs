using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class ProductBasket
    {
        [Key]
        public int ProductBasketId { get; set; }

        
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Count { get; set; } = 1;

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
