using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.UserEmail)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.UserPassword)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.ContactName)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.UserEmail).HasColumnName("UserEmail");
            this.Property(t => t.UserPassword).HasColumnName("UserPassword");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
            this.Property(t => t.PackageId).HasColumnName("PackageId");

            // Relationships
            this.HasRequired(t => t.Package)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.PackageId);

        }
    }
}
