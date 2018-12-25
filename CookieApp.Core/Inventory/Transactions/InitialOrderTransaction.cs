using System;
using System.Collections.Generic;

namespace CookieApp.Core.Inventory
{
    public sealed class InitialOrderTransaction : Transaction
    {
        public IEnumerable<CookieQuantity> List { get; }

        public InitialOrderTransaction(IEnumerable<CookieQuantity> list, DateTime dateReceived) : base(dateReceived)
        {
            List = list;
        }
    }
}