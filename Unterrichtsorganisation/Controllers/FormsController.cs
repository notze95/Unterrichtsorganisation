using Microsoft.AspNetCore.Mvc;
using Unterrichtsorganisation.Models;
using Unterrichtsorganisation.Services;

namespace Unterrichtsorganisation.Controllers {
    [ApiController]
    [Route("api/forms")]
    public class FormsController : ControllerBase {
        private readonly FormService formService;

        public FormsController(FormService formService)
        {
            this.formService = formService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Form>>> GetAll(CancellationToken ct) {
            List<Form> forms = await formService.GetAllAsync(ct);
            return Ok(forms);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Form>> GetById(int id, CancellationToken ct) {
            Form? form = await formService.GetByIdAsync(id, ct);

            if (form is null) {
                return NotFound();
            }

            return Ok(form);
        }
    }
}
