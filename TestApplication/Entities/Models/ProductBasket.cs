using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class ProductBasket
    {
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User Shipper { get; set; }
    }
}
