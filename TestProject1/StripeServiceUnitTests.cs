using NSubstitute;
using Stripe;

using UseCase2.Services;

namespace TestProject1
{
    public class StripeServiceTests
    {
        private readonly BalanceService balanceService;
        private readonly BalanceTransactionService balanceTransactionService;
        private readonly StripeService stripeService;
        private readonly CancellationToken cancellationToken;

        public StripeServiceTests()
        {
            balanceService = Substitute.For<BalanceService>();
            balanceTransactionService = Substitute.For<BalanceTransactionService>();
            stripeService = new StripeService(balanceService, balanceTransactionService);
            cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task GetBalanceAsync_CallsBalanceService_GetAsync()
        {
            // Arrange
            var expectedBalance = new Balance();
            balanceService.GetAsync(null, cancellationToken).ReturnsForAnyArgs(expectedBalance);

            // Act
            var result = await stripeService.GetBalanceAsync(cancellationToken);

            // Assert
            await balanceService.Received(1).GetAsync(null, cancellationToken);
            Assert.Equal(expectedBalance, result);
        }

        [Fact]
        public async Task GetBalanceTransactionsAsync_CallsBalanceTransactionService_ListAsync()
        {
            // Arrange
            var limit = 5;
            var startingAfter = "txn_123";
            var expectedTransactions = new StripeList<BalanceTransaction>();
            var options = new BalanceTransactionListOptions
            {
                Limit = limit,
                StartingAfter = startingAfter,
            };
            balanceTransactionService.ListAsync(options, null, cancellationToken).ReturnsForAnyArgs(expectedTransactions);

            // Act
            var result = await stripeService.GetBalanceTransactionsAsync(limit, startingAfter, cancellationToken);

            // Assert
            await balanceTransactionService.Received(1).ListAsync(Arg.Is<BalanceTransactionListOptions>(o => o.Limit == limit && o.StartingAfter == startingAfter), null, cancellationToken);
            Assert.Equal(expectedTransactions.ToString(), result.ToString());
        }

    }
}
