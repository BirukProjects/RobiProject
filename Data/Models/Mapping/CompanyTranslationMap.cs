using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CompanyTranslationMap : EntityTypeConfiguration<CompanyTranslation>
    {
        public CompanyTranslationMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyTranslationID);

            // Properties
            this.Property(t => t.Language)
                .HasMaxLength(10);

            this.Property(t => t.Description)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("CompanyTranslation");
            this.Property(t => t.CompanyTranslationID).HasColumnName("CompanyTranslationID");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.Language).HasColumnName("Language");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.CompanyTranslations)
                .HasForeignKey(d => d.CompanyId);

        }
    }
}
