using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class MapCityMap : EntityTypeConfiguration<MapCity>
    {
        public MapCityMap()
        {
            // Primary Key
            this.HasKey(t => t.MapCityId);

            // Properties
            this.Property(t => t.CityName)
                .HasMaxLength(100);

            this.Property(t => t.ZipCode)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MapCity");
            this.Property(t => t.MapCityId).HasColumnName("MapCityId");
            this.Property(t => t.MapStateOrProvinceId).HasColumnName("MapStateOrProvinceId");
            this.Property(t => t.CityName).HasColumnName("CityName");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");

            // Relationships
            this.HasOptional(t => t.MapStateOrProvince)
                .WithMany(t => t.MapCities)
                .HasForeignKey(d => d.MapStateOrProvinceId);

        }
    }
}
