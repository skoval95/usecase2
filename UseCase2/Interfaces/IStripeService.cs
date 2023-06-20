using Stripe;

namespace UseCase2.Interfaces
{
    public interface IStripeService
    {
        Task<Balance> GetBalanceAsync(CancellationToken cancellationToken = default);

        Task<StripeList<BalanceTransaction>> GetBalanceTransactionsAsync(int limit, string startingAfter, CancellationToken cancellationToken = default);
    }
}
