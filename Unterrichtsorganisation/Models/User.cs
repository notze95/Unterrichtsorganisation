using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unterrichtsorganisation.Models {
    public class User {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        internal sealed class UserConfig : IEntityTypeConfiguration<User> {
            public void Configure(EntityTypeBuilder<User> builder) {
                _ = builder.ToTable("User");

                _ = builder.HasKey(p => p.Id);

                _ = builder.Property(p => p.Id).HasColumnName("Id");
                _ = builder.Property(p => p.Firstname).HasColumnName("Firstname");
                _ = builder.Property(p => p.Lastname).HasColumnName("Lastname");
                _ = builder.Property(p => p.UserName).HasColumnName("Username");
                _ = builder.Property(p => p.Password).HasColumnName("Password");
                _ = builder.Property(p => p.RoleId).HasColumnName("RoleId");
            }
        }
    }
}
