using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CompaniesCategoryMap : EntityTypeConfiguration<CompaniesCategory>
    {
        public CompaniesCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyCategoryId);

            // Properties
            // Table & Column Mappings
            this.ToTable("CompaniesCategories");
            this.Property(t => t.CompanyCategoryId).HasColumnName("CompanyCategoryId");
            this.Property(t => t.CategoryAreaId).HasColumnName("CategoryAreaId");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.CompaniesCategories)
                .HasForeignKey(d => d.CompanyId);

        }
    }
}
