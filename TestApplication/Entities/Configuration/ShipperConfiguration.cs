using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Entities.Configuration
{
    public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.HasData(
                new Shipper
                {
                    Name = "shipper1",
                    ShipperId = 1
                },
                new Shipper
                {
                    Name = "shipper2",
                    ShipperId = 2
                }
                ); ;
        }


    }
}
