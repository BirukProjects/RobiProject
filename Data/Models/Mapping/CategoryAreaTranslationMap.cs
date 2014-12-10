using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CategoryAreaTranslationMap : EntityTypeConfiguration<CategoryAreaTranslation>
    {
        public CategoryAreaTranslationMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryAreaTranslationId);

            // Properties
            this.Property(t => t.LanguageCode)
                .HasMaxLength(10);

            this.Property(t => t.CategoryNameTranslated)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CategoryAreaTranslation");
            this.Property(t => t.CategoryAreaTranslationId).HasColumnName("CategoryAreaTranslationId");
            this.Property(t => t.LanguageCode).HasColumnName("LanguageCode");
            this.Property(t => t.CategoryNameTranslated).HasColumnName("CategoryNameTranslated");
            this.Property(t => t.CategoryAreaId).HasColumnName("CategoryAreaId");
        }
    }
}
