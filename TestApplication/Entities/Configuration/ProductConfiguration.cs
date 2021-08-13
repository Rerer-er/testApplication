
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    ProductId = 1,
                    Price = 3500,
                    Name = "product",
                    About = "ppppproo",
                    ShipperId = 1,
                    Foto = "",
                    KindId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Price = 7000,
                    Name = "product2",
                    About = "ppp ",
                    ShipperId = 2,
                    Foto = "",
                    KindId = 2
                });
            
        }


    }
}
