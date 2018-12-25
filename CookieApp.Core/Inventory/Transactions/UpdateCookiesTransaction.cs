using System;
using System.Collections.Generic;

namespace CookieApp.Core.Inventory
{
    public class UpdateCookiesTransaction : Transaction
    {
        public IEnumerable<CookieQuantity> Cookies { get; }

        public UpdateCookiesTransaction(IEnumerable<CookieQuantity> cookies, DateTime dateReceived) : base(dateReceived)
        {
            Cookies = cookies;
        }
    }
}