using Microsoft.EntityFrameworkCore;
using Unterrichtsorganisation.Models;

namespace Unterrichtsorganisation.Services {
    public class UserService {
        private readonly UnterrichtsorganisationDbContext ctx;
        public UserService(UnterrichtsorganisationDbContext ctx) {
            this.ctx = ctx;
        }
        public async Task CreateAsync(User model, CancellationToken ct = default) {
            ctx.Users.Add(model);
            await ctx.SaveChangesAsync();
        }
    }
}
