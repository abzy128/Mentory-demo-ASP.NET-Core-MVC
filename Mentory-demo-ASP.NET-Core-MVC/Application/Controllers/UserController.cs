using Mentory_demo_ASP.NET_Core_MVC.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mentory_demo_ASP.NET_Core_MVC.Application.Controllers
{
    [Route("/")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return File("index.html", "text/html");
        }
        [HttpPost("user")]
        public ActionResult<MessageResponse> GreetUser([FromBody] User user)
        {
            if (user.FirstName == null || user.LastName == null)
                return BadRequest("Please provide both first and last name.");

            return new MessageResponse { 
                Message = $"Hello, {user.FirstName} {user.LastName}!" 
            };
        }
    }
}
