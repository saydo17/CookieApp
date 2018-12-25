namespace CookieApp.Core.Inventory
{
    public class CookieStack : Entity
    {
        public virtual CookieQuantity CookieQuantity { get; set; }
        public virtual int Position { get; }

        protected CookieStack() { }

        public CookieStack(int position, Cookie cookie) : this()
        {
            Position = position;
            CookieQuantity = new CookieQuantity(0, cookie);
        }

    }
}