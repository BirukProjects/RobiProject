using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CompanyCategoryMap : EntityTypeConfiguration<CompanyCategory>
    {
        public CompanyCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyCategoryId);

            // Properties
            // Table & Column Mappings
            this.ToTable("CompanyCategories");
            this.Property(t => t.CompanyCategoryId).HasColumnName("CompanyCategoryId");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.CompanyCategories)
                .HasForeignKey(d => d.CompanyId);

        }
    }
}
