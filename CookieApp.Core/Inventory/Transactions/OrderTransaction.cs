using System;
using System.Collections.Generic;

namespace CookieApp.Core.Inventory
{
    public class OrderTransaction : Transaction
    {
        public virtual IEnumerable<CookieQuantity> Cookies { get; }

        public OrderTransaction()
        {
            
        }
        public OrderTransaction(IEnumerable<CookieQuantity> cookies, DateTime dateReceived) : base(dateReceived)
        {
            Cookies = cookies;
        }
    }
}