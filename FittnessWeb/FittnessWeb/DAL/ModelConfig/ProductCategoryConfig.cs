using FittnessWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FittnessWeb.DAL.ModelConfig
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasOne(p => p.Product)
                .WithMany(p => p.CategoryProducts)
                .HasForeignKey(p => p.ProductId);
            builder.HasOne(p=>p.Category)
                .WithMany(p=>p.CategoryProducts)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
