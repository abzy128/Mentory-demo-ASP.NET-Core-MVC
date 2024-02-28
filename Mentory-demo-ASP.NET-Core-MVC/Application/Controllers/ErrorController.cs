using Microsoft.AspNetCore.Mvc;

namespace Mentory_demo_ASP.NET_Core_MVC.Application.Controllers
{
    [Controller]
    public class ErrorController : Controller
    {
        [Route("not-found")]
        public IActionResult Error()
        {
            return File("~/not-found/index.html", "text/html");
        }
    }
}
