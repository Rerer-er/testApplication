using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Shipper
    {
        [Column("ShipperId")]
        [Key]
        public int ShipperId { get; set; }

        [Required(ErrorMessage = "Shipper name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
