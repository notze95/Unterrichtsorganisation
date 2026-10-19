using Microsoft.EntityFrameworkCore;
using Unterrichtsorganisation.Models;

namespace Unterrichtsorganisation.Services {
    public class FormService {
        private readonly UnterrichtsorganisationDbContext ctx;
        public FormService(UnterrichtsorganisationDbContext ctx) {
            this.ctx = ctx;
        }

        public async Task<List<Form>> GetAllAsync(CancellationToken ct = default) {
            return await ctx.Forms
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<Form?> GetByIdAsync(int id, CancellationToken ct = default) {
            return await ctx.Forms
                .AsNoTracking()
                .FirstOrDefaultAsync(form => form.Id == id, ct);
        }
    }
}
