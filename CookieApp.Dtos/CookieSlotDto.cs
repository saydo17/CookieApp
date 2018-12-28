namespace CookieApp.Dtos
{
    public class CookieSlotDto
    {
        public int Position { get; set; }

        public CookieQuantityDto CookieQuantity { get; set; }

        public CookieDto Cookie => CookieQuantity.Cookie;
        public int Quantity => CookieQuantity.Quantity;
    }
}