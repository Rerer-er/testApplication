using System.ComponentModel.DataAnnotations;

namespace Entities.ModelsDto
{
    public class CreateProductDto
    {

        [Required(ErrorMessage = "Kind name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        public string About { get; set; }
        [Required(ErrorMessage = "Price is a required field.")]
        public decimal? Price { get; set; }
        public string Foto { get; set; }
        public int ShipperId { get; set; }
    }
}
