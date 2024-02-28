using Mentory_demo_ASP.NET_Core_MVC.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mentory_demo_ASP.NET_Core_MVC.Application.Controllers
{
    [ApiController]
    [Route("/image")]
    public class ImageController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetImage()
        {
            return File("~/images/image.jpg", "image/jpeg");
        }
        [HttpPost]
        public IActionResult UploadImage(IFormFile image)
        {
            if (image == null)
                return BadRequest("Please provide an image file.");
            using (var stream = new FileStream("wwwroot/images/image.jpg", FileMode.Create))
            {
                image.CopyTo(stream);
            }
            return Ok(new MessageResponse {
                Message = "Image uploaded successfully." 
            });
        }
    }
}
