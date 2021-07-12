using System;
using System.Collections.Generic;
using System.Text;

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
                    Name = "product",
                    ShipperId = 1,
                    KindId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "product",
                    ShipperId = 2,
                    KindId = 2
                }
                );
        }


    }
}
