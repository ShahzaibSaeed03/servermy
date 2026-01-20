using BL;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyCAServer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactBL _contactBL;
        public ContactController(IContactBL contactBL)
        {
            _contactBL = contactBL;
        }

        [HttpPost("sendEmail")]
        public async Task<ActionResult<string>> sendEmail([FromBody] ContactFormDto form)
        {
            try
            {
                string res = await _contactBL.sendEmail(form);
                if (res == null)
                    return Unauthorized();
                return Ok(res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
