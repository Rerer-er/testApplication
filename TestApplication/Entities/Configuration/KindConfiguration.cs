using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class KindConfiguration : IEntityTypeConfiguration<Kind>
    {
        public void Configure(EntityTypeBuilder<Kind> builder)
        {
            builder.HasData(
                new Kind
                {
                    KindId = 1,
                    Name = "food1",
                    About = "about food1"
                },
                new Kind
                {
                    KindId = 2,
                    Name = "food2",
                    About = "about food2"
                }
                ); 
        }
    }
}
