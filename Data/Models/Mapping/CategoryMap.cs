using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryID);

            // Properties
            this.Property(t => t.Area)
                .HasMaxLength(100);

            this.Property(t => t.Category1)
                .HasMaxLength(100);

            this.Property(t => t.Subcategory)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Categories");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.Category1).HasColumnName("Category");
            this.Property(t => t.Subcategory).HasColumnName("Subcategory");
        }
    }
}
