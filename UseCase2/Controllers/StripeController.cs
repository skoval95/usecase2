using Microsoft.AspNetCore.Mvc;

using UseCase2.Interfaces;

namespace UseCase2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly IStripeService _stripeService;

        public StripeController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBalance(CancellationToken cancellationToken)
        {
            try
            {
                var balance = await _stripeService.GetBalance(cancellationToken);
                return Ok(balance);
            }
            catch (Stripe.StripeException e)
            {
                // Handle the Stripe errors
                return BadRequest(new { error = e.Message });
            }
            catch (Exception e)
            {
                // Handle any other errors
                return StatusCode(500, new { error = e.Message });
            }
        }
    }
}
