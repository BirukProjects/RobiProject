using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CompanyProductServiceMap : EntityTypeConfiguration<CompanyProductService>
    {
        public CompanyProductServiceMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyProductServiceId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(150);

            this.Property(t => t.Description)
                .HasMaxLength(150);

            this.Property(t => t.URL)
                .HasMaxLength(150);

            this.Property(t => t.Tag)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("CompanyProductServices");
            this.Property(t => t.CompanyProductServiceId).HasColumnName("CompanyProductServiceId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.Tag).HasColumnName("Tag");
            this.Property(t => t.companyId).HasColumnName("companyId");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.CompanyProductServices)
                .HasForeignKey(d => d.companyId);

        }
    }
}
