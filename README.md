# UC#2
### Application description
Introducing **"Balance Tracker Pro"**, a Web API designed to provide users with real-time tracking of their financial balances and transactions. This application connects with your Stripe account and gives you immediate access to your balance information as well as transaction data.

**Key Features**:

**Real-Time Balance Information**: Get up-to-the-minute balance details from your Stripe account. Whether you want to check your balance frequently or just need to know it before making a significant purchase, our app is your reliable assistant.

**Transaction History**: Get a detailed overview of your balance transactions in a chronological manner. This feature not only displays your most recent transactions but also allows you to set a limit on the number of transactions you want to review.

**After-Action Report**: Use the 'startingAfter' parameter to get a list of transactions that occurred after a specified event. This is a valuable tool for monitoring the financial impact of specific actions or understanding your financial timeline.

**Asynchronous Functionality**: The application utilizes async-await tasks for better performance and smoother user experience. It means you can request data and it will be fetched in the background without blocking the user interface, providing you with a faster, more responsive app.

**Cancellation Handling**: The application supports cancellation tokens. You can cancel a running request anytime, providing better control over your data fetch operations and saving bandwidth.

**Secure and Reliable**: Your data is fetched securely from Stripe and is always up-to-date, ensuring you can rely on the figures provided.


### Application setup
1. Install .NET 6 SDK
1. Clone the app repository with your favorite GIT client
1. Open the solution
1. Reaplce "StripeApiKey" with your API key (https://stripe.com/docs/keys) in 'appsettings.json' file
1. Run the app


### Exmaples
Here are a few examples of how to use cURL to interact with the API endpoints:
(Replace '{your-api-url}' with the actual URL)

1. ```curl -X GET 'https://\{your-api-url\}/api/balance'``` - to get balance.
1. ```curl -X GET 'https://\{your-api-url\}/transactions'``` - to get transactions with default limit.
1. ```curl -X GET 'https://\{your-api-url\}/transactions?limit=20&startingAfter=tx_123456'``` - to get transactions with provided limits.
Replace '20' with the number of transactions you want to view, 'tx_123456' with the id of the transaction you want to start viewing from.