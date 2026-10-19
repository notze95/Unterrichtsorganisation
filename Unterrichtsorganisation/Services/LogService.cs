using Unterrichtsorganisation.Models;

namespace Unterrichtsorganisation.Services {
    public class LogService {
        private readonly UnterrichtsorganisationDbContext ctx;
        public LogService(UnterrichtsorganisationDbContext ctx) {
            this.ctx = ctx;
        }
    }
}
