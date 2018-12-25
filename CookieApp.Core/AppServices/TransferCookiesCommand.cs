using System;
using System.Collections.Generic;
using CookieApp.Core.Inventory;

namespace CookieApp.Core.AppServices
{
    public class TransferCookiesCommand : ICommand
    {
        public TransferCookiesCommand(int fromInventoryId, int toInventoryId, IEnumerable<CookieQuantity> cookies, DateTime dateReceived)
        {
            FromInventoryId = fromInventoryId;
            ToInventoryId = toInventoryId;
            Cookies = cookies;
            DateReceived = dateReceived;
        }

        public int FromInventoryId { get; }
        public int ToInventoryId { get; }
        public IEnumerable<CookieQuantity> Cookies { get; }
        public DateTime DateReceived { get; }
    }
}