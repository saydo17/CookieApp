using System;

namespace CookieApp.Core.AppServices
{
    public class MakePaymentCommand : ICommand
    {
        public MakePaymentCommand(DateTime dateReceived, decimal amount, int inventoryId)
        {

            DateReceived = dateReceived;
            Amount = amount;
            InventoryId = inventoryId;
        }

        public int InventoryId { get; }
        public DateTime DateReceived { get; }
        public decimal Amount { get; }
    }
}
