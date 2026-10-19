using Unterrichtsorganisation.Models;

namespace Unterrichtsorganisation.Services {
    public class DepartmentManagerService {
        private readonly UnterrichtsorganisationDbContext ctx;
        public DepartmentManagerService(UnterrichtsorganisationDbContext ctx) {
            this.ctx = ctx;
        }
    }
}
