using DTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCAServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorksController : Controller
    {
        [Authorize]
        [HttpPost("uploadWork")]
        public async Task<ActionResult<string>> uploadWork([FromForm] IFormFile file)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var relativePath = $"/uploads/{uniqueFileName}";
            return Ok(new { filePath = relativePath });
            //return file;
        }

        //[Authorize]
        //[HttpPost("uploadWork")]
        //public async Task<ActionResult<string>> uploadWork([FromBody] string file)
        //{
        //    var authHeader = HttpContext.Request.Headers["Authorization"];
        //    return Ok(new { message = $"Authorization Header: {authHeader}" });
        //    //return file;
        //}
    }
}
