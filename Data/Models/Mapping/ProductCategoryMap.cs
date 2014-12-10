using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class ProductCategoryMap : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductCategoryId);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProductCategories");
            this.Property(t => t.ProductCategoryId).HasColumnName("ProductCategoryId");
            this.Property(t => t.CategoryAreaId).HasColumnName("CategoryAreaId");
            this.Property(t => t.CompanyProductServiceId).HasColumnName("CompanyProductServiceId");

            // Relationships
            this.HasOptional(t => t.CompanyProductService)
                .WithMany(t => t.ProductCategories)
                .HasForeignKey(d => d.CompanyProductServiceId);

        }
    }
}
