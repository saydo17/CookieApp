using System;
using System.Collections.Generic;

namespace CookieApp.Core.Inventory
{
    public class CookieTransferInTransaction : CookieTransferTransaction
    {
        public int FromInventoryId { get; }

        public CookieTransferInTransaction(IEnumerable<CookieQuantity> cookies, DateTime dateReceived, int fromInventoryId) : base(cookies, dateReceived)
        {
            FromInventoryId = fromInventoryId;
        }
    }
}