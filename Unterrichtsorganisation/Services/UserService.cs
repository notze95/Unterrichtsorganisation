using Microsoft.EntityFrameworkCore;
using Unterrichtsorganisation.Models;

namespace Unterrichtsorganisation.Services {
    public class UserService {
        private readonly UnterrichtsorganisationDbContext ctx;
        public UserService(UnterrichtsorganisationDbContext ctx) {
            this.ctx = ctx;
        }
        public async Task<User> GetUser(int id, CancellationToken ct = default) {
            User user = await ctx.Users.FirstOrDefaultAsync(x => x.Id == id, ct)
                ?? throw new KeyNotFoundException();
            return user;
        }
        public async Task CreateAsync(User model, CancellationToken ct = default) {
            ctx.Users.Add(model);
            await ctx.SaveChangesAsync();
        }

        public async Task EditAsync(User model, CancellationToken ct = default) {
            User currentUser = await ctx.Users.FirstOrDefaultAsync(x => x.Id == model.Id, ct)
                ?? throw new KeyNotFoundException();
            currentUser.Firstname = model.Firstname;
            currentUser.Lastname = model.Lastname;
            currentUser.UserName = model.UserName;
            currentUser.Password = model.Password;
            currentUser.RoleId = model.RoleId;
            await ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(User model, CancellationToken ct = default) {
            User currentUser = await ctx.Users.FirstOrDefaultAsync(x => x.Id == model.Id, ct) 
                ?? throw new KeyNotFoundException();
            ctx.Users.Remove(currentUser);
            await ctx.SaveChangesAsync();
        }
    }
}
