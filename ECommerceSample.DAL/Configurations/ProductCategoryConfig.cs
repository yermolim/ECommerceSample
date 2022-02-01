using ECommerceSample.Core.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
