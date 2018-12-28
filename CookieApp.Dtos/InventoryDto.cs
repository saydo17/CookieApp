using System;
using System.Collections.Generic;

namespace CookieApp.Dtos
{
    public class InventoryDto
    {
        public List<CookieSlotDto> CookieSlots { get; set; }

        public decimal Balance { get; set; }

        public List<CookieTransactionDto> Transactions { get; set; }
    }

    public class CookieTransactionDto
    {
        public DateTime DateEntered { get; set; }
        public DateTime DateReceived { get; set; }
    }

    public class CookieTransferInTransactionDto : CookieTransactionDto
    {
        public List<CookieQuantityDto> Cookies { get; set; }
        public int FromInventoryId { get; set; }
    }

    public class CookieQuantityDto
    {
        public CookieDto Cookie { get; set; }
        public int Quantity { get; set; }
    }

    public class CookieTransferOutTransactionDto : CookieTransactionDto
    {
        public List<CookieQuantityDto> Cookies { get; set; }
        public int ToInventoryId { get; set; }
    }

    public class OrderTransactionDto : CookieTransactionDto
    {
        public List<CookieQuantityDto> Cookies { get; set; }
    }

    public class PaymentTransactionDto : CookieTransactionDto
    {
        public decimal Amount { get; set; }
    }

    public class UpdateCookiesTransactionDto: CookieTransactionDto
    {
        public List<CookieQuantityDto> Cookies { get; set; }
    }
}