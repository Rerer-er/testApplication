using System.ComponentModel.DataAnnotations;

namespace Entities.ModelsDto
{
    public class CreateShipperDto
    {
        [Required(ErrorMessage = "Shipper name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }
        public string Foto { get; set; }
    }
}
