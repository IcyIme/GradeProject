window.stripeCheckout = {
    open: function (options) {
        // Implement logic to open Stripe checkout modal here
        // Example: Stripe Checkout initialization
        var handler = StripeCheckout.configure({
            key: options.key,
            amount: options.amount,
            currency: options.currency,
            locale: options.locale,
            description: options.description,
            token: function (token) {
                // Send the token to your server or handle it as needed
                // Example: Send token to Blazor component
                DotNet.invokeMethodAsync('GradeProject', 'ReceiveToken', token.id);
            }
        });

        handler.open({
            name: options.name,
            description: options.description,
            amount: options.amount
        });
    }
};