using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class MapStateOrProvinceMap : EntityTypeConfiguration<MapStateOrProvince>
    {
        public MapStateOrProvinceMap()
        {
            // Primary Key
            this.HasKey(t => t.MapStateOrProvinceId);

            // Properties
            this.Property(t => t.StateOrProvinceName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MapStateOrProvince");
            this.Property(t => t.MapStateOrProvinceId).HasColumnName("MapStateOrProvinceId");
            this.Property(t => t.MapCountryId).HasColumnName("MapCountryId");
            this.Property(t => t.StateOrProvinceName).HasColumnName("StateOrProvinceName");

            // Relationships
            this.HasOptional(t => t.MapCountry)
                .WithMany(t => t.MapStateOrProvinces)
                .HasForeignKey(d => d.MapCountryId);

        }
    }
}
