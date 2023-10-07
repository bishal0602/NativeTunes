using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NativeTunes.Domain.MarketplaceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NativeTunes.Domain.MarketplaceAggregate.ValueObjects;

namespace NativeTunes.Infrastructure.Configurations
{
    public class MarketplaceConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasConversion(id => id.Value, value => ProductId.Create(value));

            builder.Property(e => e.Price)
                   .HasColumnType("decimal(18, 2)") // Adjust the precision and scale as needed
                   .IsRequired();
        }
    }

}
