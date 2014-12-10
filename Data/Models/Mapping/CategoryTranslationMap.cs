using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CategoryTranslationMap : EntityTypeConfiguration<CategoryTranslation>
    {
        public CategoryTranslationMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryTranslationId);

            // Properties
            this.Property(t => t.CategoryTranslationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Languagecode)
                .HasMaxLength(10);

            this.Property(t => t.Area)
                .HasMaxLength(100);

            this.Property(t => t.Category)
                .HasMaxLength(100);

            this.Property(t => t.Subcategory)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CategoryTranslation");
            this.Property(t => t.CategoryTranslationId).HasColumnName("CategoryTranslationId");
            this.Property(t => t.Languagecode).HasColumnName("Languagecode");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.Subcategory).HasColumnName("Subcategory");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
        }
    }
}
