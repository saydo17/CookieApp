using System;
using System.Collections.Generic;
using System.Linq;

namespace CookieApp.Core.Inventory
{
    public abstract class CookieInventory : Entity, ICookieInventory
    {
        public CookieInventory()
        {
            Transactions = new List<Transaction>();
            Stacks = new List<CookieStack>()
            {
                new CookieStack(0, Cookie.DosiSo),
                new CookieStack(1, Cookie.Samoas),
                new CookieStack(2, Cookie.Savannah),
                new CookieStack(3, Cookie.Smors),
                new CookieStack(4, Cookie.Tagalongs),
                new CookieStack(5, Cookie.ThinMints),
                new CookieStack(6, Cookie.ToffeeTastic),
                new CookieStack(7, Cookie.Trefoils)
            };
        }

        public virtual decimal Balance { get; set; }
        public virtual IList<CookieStack> Stacks { get; set; }
        public virtual IList<Transaction> Transactions { get; set; }
        public virtual decimal Variance { get; }

        public virtual void TransferCookiesIn(IEnumerable<CookieQuantity> cookieQuantities, DateTime dateReceived, int fromInventoryId)
        {
            var quantities = cookieQuantities.ToList();
            Balance += quantities.Sum(c => c.TotalAmount);

            foreach (var cookie in quantities)
            {
                var stack = Stacks.FirstOrDefault(s => s.CookieQuantity.Cookie == cookie.Cookie);
                if(stack == null)
                    throw new InvalidOperationException($"Cookie type {cookie.Cookie} not found.");
                stack.CookieQuantity += cookie;
            }


            Transactions.Add(new CookieTransferInTransaction(quantities, dateReceived, fromInventoryId));
        }

        public virtual void TransferCookiesOut(IEnumerable<CookieQuantity> cookies, DateTime dateReceived, int toInventoryId)
        {

            var quantities = cookies.ToList();
            Balance -= quantities.Sum(c => c.TotalAmount);

            foreach (var cookie in quantities)
            {
                var stack = Stacks.FirstOrDefault(s => s.CookieQuantity.Cookie == cookie.Cookie);
                if (stack == null)
                    throw new InvalidOperationException($"Cookie type {cookie.Cookie} not found.");
                stack.CookieQuantity -= cookie;
            }

            Transactions.Add(new CookieTransferOutTransaction(quantities, dateReceived, toInventoryId));
        }

        public virtual void UpdateCookies(IEnumerable<CookieQuantity> cookies, DateTime dateReceived)
        {
            var quantities = cookies.ToList();
            foreach (var stack in Stacks)
            {
                var cookieQuantity = quantities.FirstOrDefault(c => c.Cookie == stack.CookieQuantity.Cookie);
                if (cookieQuantity == null)
                {
                    //Zero out any stack that wasnt included in the update
                    stack.CookieQuantity -= stack.CookieQuantity;
                }

                stack.CookieQuantity = cookieQuantity;
            }

            Transactions.Add(new UpdateCookiesTransaction(quantities, dateReceived));
        }
    }
}