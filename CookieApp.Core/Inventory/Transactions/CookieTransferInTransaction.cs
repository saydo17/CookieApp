using System;
using System.Collections.Generic;

namespace CookieApp.Core.Inventory
{
    public class CookieTransferInTransaction : CookieTransaction
    {
        public virtual int FromInventoryId { get; }
        public virtual IEnumerable<CookieQuantity> Cookies { get; }

        public CookieTransferInTransaction()
        {
            
        }

        public CookieTransferInTransaction(IEnumerable<CookieQuantity> cookies, DateTime dateReceived, int fromInventoryId) : base(dateReceived)
        {
            Cookies = cookies;
            FromInventoryId = fromInventoryId;
        }
    }
}