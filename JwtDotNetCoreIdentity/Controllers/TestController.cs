using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtDotNetCoreIdentity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult TestConnection()
        {
            return Ok("Connection success!");
        }

        [HttpGet]
        [Authorize]
        public IActionResult TestAuthorize()
        {
            return Ok("You are authorized!");
        }

        [HttpGet]
        [Authorize(Roles = "Visitor")]
        public IActionResult TestRole()
        {
            return Ok("Visitor Role Authorized!");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult TestRolePartTwo()
        {
            return Ok("Administrator Role Authorized!");
        }
    }
}
