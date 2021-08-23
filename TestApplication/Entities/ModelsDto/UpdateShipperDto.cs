using System.ComponentModel.DataAnnotations;

namespace Entities.ModelsDto
{
    public class UpdateShipperDto
    {
        [Required(ErrorMessage = "Shipper name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public decimal LocationLat { get; set; }
        public decimal LocationLng { get; set; }
        public string Foto { get; set; }
    }
}
