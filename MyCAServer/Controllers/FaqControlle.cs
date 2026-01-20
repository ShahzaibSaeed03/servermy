using BL;
using DAL;
using DAL.Models;
using DTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyCAServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaqController : Controller
    {
        private readonly IFaqBL _faqBL;

        public FaqController(IFaqBL faqBL)
        {
            _faqBL = faqBL;
        }

        [HttpGet("get-faq")]
        public async Task<ActionResult<IEnumerable<object>>> getFaq()
        {
            try
            {
                var list = await _faqBL.GetFaq();
                return Ok(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500);
            }
        }
    }
}
