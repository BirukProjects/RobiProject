using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CompanyMemberMap : EntityTypeConfiguration<CompanyMember>
    {
        public CompanyMemberMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyMemberId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.UrlProfile)
                .HasMaxLength(200);

            this.Property(t => t.PublicEmail)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("CompanyMembers");
            this.Property(t => t.CompanyMemberId).HasColumnName("CompanyMemberId");
            this.Property(t => t.CompanyRoleId).HasColumnName("CompanyRoleId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UrlProfile).HasColumnName("UrlProfile");
            this.Property(t => t.PublicEmail).HasColumnName("PublicEmail");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.CompanyMembers)
                .HasForeignKey(d => d.CompanyId);
            this.HasOptional(t => t.CompanyRole)
                .WithMany(t => t.CompanyMembers)
                .HasForeignKey(d => d.CompanyRoleId);

        }
    }
}
