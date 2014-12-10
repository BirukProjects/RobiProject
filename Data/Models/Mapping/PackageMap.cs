using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class PackageMap : EntityTypeConfiguration<Package>
    {
        public PackageMap()
        {
            // Primary Key
            this.HasKey(t => t.PackageId);

            // Properties
            this.Property(t => t.PackageName)
                .HasMaxLength(100);

            this.Property(t => t.PackageCode)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Packages");
            this.Property(t => t.PackageId).HasColumnName("PackageId");
            this.Property(t => t.PackageName).HasColumnName("PackageName");
            this.Property(t => t.PackageValue).HasColumnName("PackageValue");
            this.Property(t => t.PackageShowOnline).HasColumnName("PackageShowOnline");
            this.Property(t => t.PackageCode).HasColumnName("PackageCode");
        }
    }
}
