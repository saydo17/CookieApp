using System;
using System.Collections.Generic;

namespace CookieApp.Core.Inventory
{
    public interface ICookieInventory
    {
        decimal Balance { get; set; }
        IList<CookieStack> Stacks { get; set; }
        IList<CookieTransaction> Transactions { get; set; }
        decimal Variance { get; }

        void TransferCookiesIn(IEnumerable<CookieQuantity> cookieQuantities, DateTime dateReceived, int fromInventoryId);
        void TransferCookiesOut(IEnumerable<CookieQuantity> cookies, DateTime dateReceived, int toInventoryId);
        void UpdateCookies(IEnumerable<CookieQuantity> cookies, DateTime dateReceived);
    }
}