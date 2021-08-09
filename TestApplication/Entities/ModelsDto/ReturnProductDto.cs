namespace Entities.ModelsDto
{
    public class ReturnProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string About { get; set; }
        public decimal Price { get; set; }
        public string Foto { get; set; }
    }
}
