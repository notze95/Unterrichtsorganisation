using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unterrichtsorganisation.Models {
    public class DepartmentManager {
        public string Department { get; set; }
        public int UserId { get; set; }

        internal sealed class DepartmentManagerConfig : IEntityTypeConfiguration<DepartmentManager> {
            public void Configure(EntityTypeBuilder<DepartmentManager> builder) {
                _ = builder.ToTable("DepartmentManager");

                _ = builder.HasKey(p => new { p.Department, p.UserId });

                _ = builder.Property(p => p.Department).HasColumnName("Department");
                _ = builder.Property(p => p.UserId).HasColumnName("UserId");
            }
        }
    }
}
