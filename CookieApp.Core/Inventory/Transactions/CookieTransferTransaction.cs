using System;
using System.Collections.Generic;

namespace CookieApp.Core.Inventory
{
    public class CookieTransferTransaction : Transaction
    {
        public IEnumerable<CookieQuantity> Cookies { get; }

        public CookieTransferTransaction(IEnumerable<CookieQuantity> cookies, DateTime dateReceived) : base(dateReceived)
        {
            Cookies = cookies;
        }
    }
}