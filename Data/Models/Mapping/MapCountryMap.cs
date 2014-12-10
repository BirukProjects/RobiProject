using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class MapCountryMap : EntityTypeConfiguration<MapCountry>
    {
        public MapCountryMap()
        {
            // Primary Key
            this.HasKey(t => t.MapCountryId);

            // Properties
            this.Property(t => t.CountryName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MapCountry");
            this.Property(t => t.MapCountryId).HasColumnName("MapCountryId");
            this.Property(t => t.MapAreaId).HasColumnName("MapAreaId");
            this.Property(t => t.CountryName).HasColumnName("CountryName");

            // Relationships
            this.HasOptional(t => t.MapArea)
                .WithMany(t => t.MapCountries)
                .HasForeignKey(d => d.MapAreaId);

        }
    }
}
