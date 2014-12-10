using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class PreferencesKeyMap : EntityTypeConfiguration<PreferencesKey>
    {
        public PreferencesKeyMap()
        {
            // Primary Key
            this.HasKey(t => t.PreferenceKeyId);

            // Properties
            this.Property(t => t.KeyName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.DefaultValue)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("PreferencesKeys");
            this.Property(t => t.PreferenceKeyId).HasColumnName("PreferenceKeyId");
            this.Property(t => t.KeyName).HasColumnName("KeyName");
            this.Property(t => t.DefaultValue).HasColumnName("DefaultValue");
        }
    }
}
