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
        [Route("balance")]
        public async Task<IActionResult> GetBalance(CancellationToken cancellationToken = default)
        {
            var balance = await _stripeService.GetBalanceAsync(cancellationToken);
            return Ok(balance);
        }

        [HttpGet]
        [Route("transactions")]
        public async Task<IActionResult> GetBalanceTransactions(int limit = 10, string startingAfter = null, CancellationToken cancellationToken = default)
        {
            var result = await _stripeService.GetBalanceTransactionsAsync(limit, startingAfter, cancellationToken);
            return Ok(result);
        }
    }
}
