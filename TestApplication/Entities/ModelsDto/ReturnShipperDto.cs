namespace Entities.ModelsDto
{
    public class ReturnShipperDto
    {
        public int ShipperId { get; set; }
        public string Name { get; set; }
        public decimal LocationLat { get; set; }
        public decimal LocationLng { get; set; }
        public string Foto { get; set; }
        public decimal FinalRating { get; set; }
    }
}
