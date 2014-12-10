using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class UserPreferenceMap : EntityTypeConfiguration<UserPreference>
    {
        public UserPreferenceMap()
        {
            // Primary Key
            this.HasKey(t => t.UserPreferenceId);

            // Properties
            this.Property(t => t.MainCountryCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.SecondCountryCode)
                .HasMaxLength(10);

            this.Property(t => t.ThirdCountryCode)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("UserPreferences");
            this.Property(t => t.UserPreferenceId).HasColumnName("UserPreferenceId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.MainCountryCode).HasColumnName("MainCountryCode");
            this.Property(t => t.SecondCountryCode).HasColumnName("SecondCountryCode");
            this.Property(t => t.ThirdCountryCode).HasColumnName("ThirdCountryCode");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.UserPreferences)
                .HasForeignKey(d => d.UserId);

        }
    }
}
