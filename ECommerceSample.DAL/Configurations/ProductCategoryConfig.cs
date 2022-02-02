using ECommerceSample.Core.Models.Products;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerceSample.DAL.Configurations
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");

            builder.Property(pc => pc.Id)
                .HasConversion(new GuidToStringConverter());

            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.Name)
                .IsRequired();
        }

    }
}
