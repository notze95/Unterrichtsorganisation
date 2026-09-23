using Microsoft.AspNetCore.Mvc;
using Unterrichtsorganisation.Models;
using Unterrichtsorganisation.Services;

namespace Unterrichtsorganisation.Controllers {
    [ApiController]
    [Route("Unterrichtsorganisation/")]
    public class HomeController : ControllerBase {
        private UserService userService { get; set; }
        public HomeController(UserService userService) {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult> Index() {
            User user = new() {
                Id = 1,
                Firstname = "TestVorname",
                Lastname = "TestNachname",
                UserName = "TestUser",
                Password = "OHHVerschlüsselt",
                RoleId = 1
            };
            await userService.CreateAsync(user);
            return Ok();
        }

        public async Task<ActionResult> Login() {
            return null;
        }

        public async Task<ActionResult> CreateForm() {
            return null;
        }

        public async Task<ActionResult> GetForm() {
            return null;
        }
    }
}
