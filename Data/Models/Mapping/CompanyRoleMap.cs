using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CompanyRoleMap : EntityTypeConfiguration<CompanyRole>
    {
        public CompanyRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyRoleId);

            // Properties
            this.Property(t => t.CompanyRoleName)
                .HasMaxLength(100);

            this.Property(t => t.CompanyRoleDescription)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CompanyRoles");
            this.Property(t => t.CompanyRoleId).HasColumnName("CompanyRoleId");
            this.Property(t => t.CompanyRoleName).HasColumnName("CompanyRoleName");
            this.Property(t => t.CompanyRoleDescription).HasColumnName("CompanyRoleDescription");
            this.Property(t => t.Approved).HasColumnName("Approved");
        }
    }
}
