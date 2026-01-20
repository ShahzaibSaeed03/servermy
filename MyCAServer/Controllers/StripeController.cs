using BL;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace MyCAServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StripeController : Controller
    {
        private readonly IUserBL _userBL;

        public StripeController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [Authorize]
        [HttpPost("create-checkout-session/{quantity}")]
        public ActionResult Create(int quantity)
        {
            var domain = "http://localhost:4200";
            var options = new SessionCreateOptions
            {
                UiMode = "embedded",
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    Price = "price_1R4hdqLIxobea5p9BK1e89Zf",
                    Quantity = quantity,
                },
            },
                Mode = "subscription",
                ReturnUrl = domain + "/return?session_id={CHECKOUT_SESSION_ID}",
                Metadata = new Dictionary<string, string>
                {
                    { "userId", "3002" }
                }
            };
            var service = new SessionService();
            Session session = service.Create(options);
            Console.WriteLine("sessoin");
            return Json(new { clientSecret = session.ClientSecret });
        }

        [Authorize]
        [HttpGet("session-status")]
        public ActionResult SessionStatus([FromQuery] string session_id)
        {
            var sessionService = new SessionService();
            Session session = sessionService.Get(session_id);

            return Json(new { status = session.Status, customer_email = session.CustomerDetails.Email });
        }


        [HttpPost("stripe-webhook")]
        public async Task<IActionResult> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    Request.Headers["Stripe-Signature"],
                    "whsec_U2JNUQxqLPWrxwh3S5BqpzSNZxRIyfKX"
                );

                if (stripeEvent.Type == "checkout.session.completed")
                {
                    var session = stripeEvent.Data.Object as Session;
                    int userId = int.Parse(session.Metadata["userId"]);
                    Console.WriteLine(userId);
                    await _userBL.AddTokens(userId, 5);

                    Console.WriteLine($"✅ Tokens added to user {userId}");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Webhook error: {ex.Message}");
            }
        }
    }
}
