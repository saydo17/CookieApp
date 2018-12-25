using System;

namespace CookieApp.Core.Inventory
{
    public class GirlScoutCookieInventory : CookieInventory
    {
        public virtual void MakePayment(decimal amount, DateTime dateReceived)
        {
            Balance -= amount;
            Transactions.Add(new PaymentTransaction(amount, dateReceived));
        }
    }
}