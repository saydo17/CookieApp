using System;

namespace CookieApp.Core.Inventory
{
    public class PaymentTransaction : CookieTransaction
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