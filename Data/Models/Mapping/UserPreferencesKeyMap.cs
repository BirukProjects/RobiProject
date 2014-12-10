using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class UserPreferencesKeyMap : EntityTypeConfiguration<UserPreferencesKey>
    {
        public UserPreferencesKeyMap()
        {
            // Primary Key
            this.HasKey(t => t.UserPreferencesKey1);

            // Properties
            this.Property(t => t.KeyValueOverrided)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("UserPreferencesKeys");
            this.Property(t => t.UserPreferencesKey1).HasColumnName("UserPreferencesKey");
            this.Property(t => t.KeyValueOverrided).HasColumnName("KeyValueOverrided");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.PreferenceKeyId).HasColumnName("PreferenceKeyId");

            // Relationships
            this.HasOptional(t => t.PreferencesKey)
                .WithMany(t => t.UserPreferencesKeys)
                .HasForeignKey(d => d.PreferenceKeyId);
            this.HasOptional(t => t.User)
                .WithMany(t => t.UserPreferencesKeys)
                .HasForeignKey(d => d.UserId);

        }
    }
}
