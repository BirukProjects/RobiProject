using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyId);

            // Properties
            this.Property(t => t.CompanyName)
                .HasMaxLength(150);

            this.Property(t => t.CompanyWebsite)
                .HasMaxLength(150);

            this.Property(t => t.CompanyEmail1)
                .HasMaxLength(100);

            this.Property(t => t.CompanyEmail2)
                .HasMaxLength(100);

            this.Property(t => t.CompanyTelephone)
                .HasMaxLength(100);

            this.Property(t => t.CompanyLogoPath)
                .HasMaxLength(200);

            this.Property(t => t.turnover)
                .HasMaxLength(100);

            this.Property(t => t.numberOfEmployees)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Companies");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.CompanyWebsite).HasColumnName("CompanyWebsite");
            this.Property(t => t.CompanyEmail1).HasColumnName("CompanyEmail1");
            this.Property(t => t.CompanyEmail2).HasColumnName("CompanyEmail2");
            this.Property(t => t.CompanyTelephone).HasColumnName("CompanyTelephone");
            this.Property(t => t.CompanyTypeId).HasColumnName("CompanyTypeId");
            this.Property(t => t.UserOwnerId).HasColumnName("UserOwnerId");
            this.Property(t => t.UserCreatorId).HasColumnName("UserCreatorId");
            this.Property(t => t.CompanyLogoPath).HasColumnName("CompanyLogoPath");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.LastUpdateDate).HasColumnName("LastUpdateDate");
            this.Property(t => t.CompanyFoundedDate).HasColumnName("CompanyFoundedDate");
            this.Property(t => t.turnover).HasColumnName("turnover");
            this.Property(t => t.numberOfEmployees).HasColumnName("numberOfEmployees");
            this.Property(t => t.companydescription).HasColumnName("companydescription");

            // Relationships
            this.HasOptional(t => t.CompanyType)
                .WithMany(t => t.Companies)
                .HasForeignKey(d => d.CompanyTypeId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Companies)
                .HasForeignKey(d => d.UserOwnerId);
            this.HasRequired(t => t.User1)
                .WithMany(t => t.Companies1)
                .HasForeignKey(d => d.UserCreatorId);

        }
    }
}
