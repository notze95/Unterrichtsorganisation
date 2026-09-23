using Unterrichtsorganisation.Models;

namespace Unterrichtsorganisation.Services {
    public class FormService {
        private readonly UnterrichtsorganisationDbContext ctx;
        public FormService(UnterrichtsorganisationDbContext ctx) {
            this.ctx = ctx;
        }
    }
}
