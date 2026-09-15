using Microsoft.EntityFrameworkCore;

namespace Unterrichtsorganisation.Models {
    public class UnterrichtsorganisationDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("");
    }
}
