using System;
using System.Collections.Generic;
using System.Linq;

namespace CookieApp.Core.Inventory
{
    public class TroopCookieInventory : CookieInventory
    {

        public virtual void AddCookiesFromCupboard(IEnumerable<CookieQuantity> cookies, DateTime dateReceived)
        {
            var quantities = cookies.ToList();
            Balance += quantities.Sum(c => c.TotalAmount);

            foreach (var cookie in quantities)
            {
                var stack = Stacks.FirstOrDefault(s => s.CookieQuantity.Cookie == cookie.Cookie);
                if (stack == null)
                    throw new InvalidOperationException($"Cookie type {cookie.Cookie} not found.");
                stack.CookieQuantity += cookie;
            }


            Transactions.Add(new InitialOrderTransaction(quantities, dateReceived));
        }
    }
}