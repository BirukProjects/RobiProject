using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CompanyPortfolioMap : EntityTypeConfiguration<CompanyPortfolio>
    {
        public CompanyPortfolioMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyPortfolioId);

            // Properties
            this.Property(t => t.CompanyPortfolioName)
                .HasMaxLength(100);

            this.Property(t => t.CompanyPortfolioUrl)
                .HasMaxLength(100);

            this.Property(t => t.CompanyPortfolioDescription)
                .HasMaxLength(100);

            this.Property(t => t.CompanyPortfolioTags)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("CompanyPortfolio");
            this.Property(t => t.CompanyPortfolioId).HasColumnName("CompanyPortfolioId");
            this.Property(t => t.CompanyPortfolioName).HasColumnName("CompanyPortfolioName");
            this.Property(t => t.CompanyPortfolioUrl).HasColumnName("CompanyPortfolioUrl");
            this.Property(t => t.CompanyPortfolioDescription).HasColumnName("CompanyPortfolioDescription");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.CompanyPortfolioTags).HasColumnName("CompanyPortfolioTags");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.CompanyPortfolios)
                .HasForeignKey(d => d.CompanyId);

        }
    }
}
