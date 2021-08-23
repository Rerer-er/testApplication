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

        public decimal CountRating { get; set; } = 0;

        public decimal SumRating { get; set; } = 0;

        public decimal FinalRating { get; set; } = 0;

        // Todo:  Add CountProduct and grade(1-5 stars)
        public ICollection<Product> Products { get; set; }
        public decimal LocationLat { get; set; }
        public decimal LocationLng { get; set; }
        public string Foto { get; set; }
    }
}
