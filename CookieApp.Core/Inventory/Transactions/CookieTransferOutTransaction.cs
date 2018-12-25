using System;
using System.Collections.Generic;

namespace CookieApp.Core.Inventory
{
    public class CookieTransferOutTransaction : CookieTransferTransaction
    {
        public int ToInventoryId { get; }

        public CookieTransferOutTransaction(IEnumerable<CookieQuantity> cookies, DateTime dateReceived, int toInventoryId) : base(cookies, dateReceived)
        {
            ToInventoryId = toInventoryId;
        }
    }
}