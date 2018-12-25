using System;

namespace CookieApp.Core.Inventory
{
    public class PaymentTransaction : Transaction
    {
        public PaymentTransaction(decimal amount, DateTime dateReceived) : base(dateReceived)
        {
            Amount = amount;
        }

        public decimal Amount { get; }
    }
}