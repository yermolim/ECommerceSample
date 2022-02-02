using ECommerceSample.Core.Models.Products;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerceSample.DAL.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Property(product => product.Id)
                .HasConversion(new GuidToStringConverter());

            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name)
                .IsRequired();

            builder.HasOne(product => product.ProductCategory)
                .WithMany(pc => pc.Products)
                .HasForeignKey(product => product.ProductCategoryId);
        }
    }
}
