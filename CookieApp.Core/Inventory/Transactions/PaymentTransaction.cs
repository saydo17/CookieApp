using System;

namespace CookieApp.Core.Inventory
{
    public class PaymentTransaction : Transaction
    {
        protected PaymentTransaction()
        {
            
        }
        public PaymentTransaction(decimal amount, DateTime dateReceived) : base(dateReceived)
        {
            Amount = amount;
        }

        public virtual decimal Amount { get; }
    }
}