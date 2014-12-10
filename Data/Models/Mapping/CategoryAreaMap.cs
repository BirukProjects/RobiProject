using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CategoryAreaMap : EntityTypeConfiguration<CategoryArea>
    {
        public CategoryAreaMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryAreaId);

            // Properties
            this.Property(t => t.CategoryName)
                .HasMaxLength(100);

            this.Property(t => t.IconPath)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("CategoryArea");
            this.Property(t => t.CategoryAreaId).HasColumnName("CategoryAreaId");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Approved).HasColumnName("Approved");
            this.Property(t => t.IconPath).HasColumnName("IconPath");

            // Relationships
            this.HasOptional(t => t.Category)
                .WithMany(t => t.CategoryAreas)
                .HasForeignKey(d => d.CategoryID);

        }
    }
}
