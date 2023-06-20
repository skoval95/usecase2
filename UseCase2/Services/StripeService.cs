using Stripe;
using UseCase2.Interfaces;

namespace UseCase2.Services
{
    public class StripeService : IStripeService
    {
        private readonly BalanceService balanceService;
        private readonly BalanceTransactionService balanceTransactionService;

        public StripeService(BalanceService balanceService, BalanceTransactionService balanceTransactionService)
        {
            this.balanceService = balanceService;
            this.balanceTransactionService = balanceTransactionService;
        }

        public Task<Balance> GetBalanceAsync(CancellationToken cancellationToken = default)
            => balanceService.GetAsync(cancellationToken: cancellationToken);

        public Task<StripeList<BalanceTransaction>> GetBalanceTransactionsAsync(int limit, string startingAfter, CancellationToken cancellationToken = default)
        {
            var options = new BalanceTransactionListOptions
            {
                Limit = limit,
                StartingAfter = startingAfter,
            };

            return balanceTransactionService.ListAsync(options, cancellationToken: cancellationToken);
        }
    }
}
