using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class CompanyTypeMap : EntityTypeConfiguration<CompanyType>
    {
        public CompanyTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyTypeId);

            // Properties
            this.Property(t => t.CompanyTypeName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CompanyType");
            this.Property(t => t.CompanyTypeId).HasColumnName("CompanyTypeId");
            this.Property(t => t.CompanyTypeName).HasColumnName("CompanyTypeName");
        }
    }
}
