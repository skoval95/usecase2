using Stripe;

using UseCase2.Interfaces;

namespace UseCase2.Services
{
    public class StripeService : IStripeService
    {
        private readonly BalanceService balanceService;

        public StripeService(BalanceService balanceService)
        {
            this.balanceService = balanceService;
        }

        public Task<Balance> GetBalance(CancellationToken cancellationToken)
            => balanceService.GetAsync(cancellationToken: cancellationToken);
    }
}
