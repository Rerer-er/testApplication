using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Product
    {
        [Column("ProductId")]
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "Price is a required field.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product about is a required field.")]
        [MaxLength(255, ErrorMessage = "Maximum length for the about is 255 characters.")]
        public string About { get; set; }
           
        [ForeignKey(nameof(Kind))]
        public int KindId { get; set; }
        public Kind Kind { get; set; }

        [ForeignKey(nameof(Shipper))]
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }

        [Required(ErrorMessage = "Product Foto is a required field.")]
        public string Foto { get; set; }

    }
}
