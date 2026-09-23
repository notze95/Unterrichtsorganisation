using Microsoft.EntityFrameworkCore;
using static Unterrichtsorganisation.Models.DepartmentManager;
using static Unterrichtsorganisation.Models.User;

namespace Unterrichtsorganisation.Models {
    public class UnterrichtsorganisationDbContext : DbContext {
        public UnterrichtsorganisationDbContext(DbContextOptions<UnterrichtsorganisationDbContext> options) : base(options) {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<DepartmentManager> DepartmentManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            new DepartmentManagerConfig().Configure(modelBuilder.Entity<DepartmentManager>());
            new UserConfig().Configure(modelBuilder.Entity<User>());
        }
    }
}
