using System;
using System.Collections.Generic;
using CookieApp.Core.Inventory;
using CookieApp.Dtos;

namespace CookieApp.Core.AppServices
{
    public class AddCookiesFromCupboardCommand : ICommand
    {
        public IEnumerable<CookieQuantity> Cookies { get; }
        public DateTime DateReceived { get; }
        public int TroopInventoryId { get; }

        public AddCookiesFromCupboardCommand(IEnumerable<CookieQuantity> cookies, DateTime dateReceived, int troopInventoryId)
        {
            Cookies = cookies;
            DateReceived = dateReceived;
            TroopInventoryId = troopInventoryId;
        }
    }
}