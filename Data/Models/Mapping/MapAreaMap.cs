using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class MapAreaMap : EntityTypeConfiguration<MapArea>
    {
        public MapAreaMap()
        {
            // Primary Key
            this.HasKey(t => t.MapAreaId);

            // Properties
            this.Property(t => t.MapAreaName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MapArea");
            this.Property(t => t.MapAreaId).HasColumnName("MapAreaId");
            this.Property(t => t.MapAreaName).HasColumnName("MapAreaName");
        }
    }
}
