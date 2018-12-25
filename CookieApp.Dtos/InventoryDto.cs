using System.Collections.Generic;

namespace CookieApp.Dtos
{
    public class InventoryDto
    {
        public List<CookieSlotDto> CookieSlots { get; set; }

        public decimal Balance { get; set; }

        //TODO Transactions
    }
}