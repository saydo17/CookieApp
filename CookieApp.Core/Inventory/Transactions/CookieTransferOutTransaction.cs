using System;
using System.Collections.Generic;

namespace CookieApp.Core.Inventory
{
    public class CookieTransferOutTransaction : CookieTransaction
    {
        public virtual int ToInventoryId { get; }
        public virtual IEnumerable<CookieQuantity> Cookies { get; }

        protected CookieTransferOutTransaction()
        {
            
        }
        public CookieTransferOutTransaction(IEnumerable<CookieQuantity> cookies, DateTime dateReceived, int toInventoryId) : base(dateReceived)
        {
            Cookies = cookies;
            ToInventoryId = toInventoryId;
        }
    }
}