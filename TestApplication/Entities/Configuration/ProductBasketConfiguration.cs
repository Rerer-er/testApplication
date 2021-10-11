using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class ProductBasketConfiguration : IEntityTypeConfiguration<ProductBasket>
    {
        public void Configure(EntityTypeBuilder<ProductBasket> builder)
        {
            //builder.HasData(
            //    new ProductBasket
            //    {
            //        ProductId = 1,
            //        UserId = "",

            //    });
        }
    }
}
