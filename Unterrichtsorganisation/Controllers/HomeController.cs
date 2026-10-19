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
            //var client = new OneRosterClient(
            //    tenantId,
            //    clientId,
            //    clientSecret);

            //var users = await client.ReadAsStringAsync(
            //    resource: "/ims/oneroster/rostering/v1p1/users",
            //    envelope: "users",
            //    limit: 100,
            //    offset: 0);


            //User user = new() {
            //    Id = 2,
            //    Firstname = "Silas",
            //    Lastname = "AAlbrecht",
            //    UserName = "Salbrecht",
            //    Password = "IchBinSOGeilAufSpecki123",
            //    RoleId = 3
            //};
            //await userService.CreateAsync(user);
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
