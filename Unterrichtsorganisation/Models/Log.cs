using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unterrichtsorganisation.Models {
    public class Log {
        public int Id { get; set; }
        public string Entry { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }

        internal sealed class LogConfig : IEntityTypeConfiguration<Log> {
            public void Configure(EntityTypeBuilder<Log> builder) {
                _ = builder.ToTable("Log");

                _ = builder.HasKey(p => p.Id);

                _ = builder.Property(p => p.Id).HasColumnName("Id");
                _ = builder.Property(p => p.Entry).HasColumnName("Entry");
                _ = builder.Property(p => p.UserId).HasColumnName("UserId");
                _ = builder.Property(p => p.Timestamp).HasColumnName("Timestamp");
            }
        }
    }
}
