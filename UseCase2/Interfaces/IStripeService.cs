using Stripe;

namespace UseCase2.Interfaces
{
    public interface IStripeService
    {
        Task<Balance> GetBalance(CancellationToken cancellationToken);
    }
}
