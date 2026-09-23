using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unterrichtsorganisation.Models {
    public class Form {
        public int Id { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string ContentJson { get; set; }

        internal sealed class FormConfig : IEntityTypeConfiguration<Form> {
            public void Configure(EntityTypeBuilder<Form> builder) {
                _ = builder.ToTable("Form");

                _ = builder.HasKey(p => p.Id);

                _ = builder.Property(p => p.Id).HasColumnName("Id");
                _ = builder.Property(p => p.Status).HasColumnName("Status");
                _ = builder.Property(p => p.UserId).HasColumnName("UserId");
                _ = builder.Property(p => p.LastModifiedOn).HasColumnName("LastModifiedOn");
                _ = builder.Property(p => p.ContentJson).HasColumnName("ContentJson");
            }
        }
    }
}
