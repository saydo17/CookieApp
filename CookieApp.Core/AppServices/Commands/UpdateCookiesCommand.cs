using System;
using System.Collections.Generic;
using CookieApp.Core.Inventory;

namespace CookieApp.Core.AppServices
{
    public class UpdateCookiesCommand : ICommand
    {
        public UpdateCookiesCommand(IEnumerable<CookieQuantity> cookies, DateTime dateReceived, int inventoryId)
        {
            Cookies = cookies;
            DateReceived = dateReceived;
            InventoryId = inventoryId;
        }

        public IEnumerable<CookieQuantity> Cookies { get; }
        public DateTime DateReceived { get; }
        public int InventoryId { get; }

    }
}