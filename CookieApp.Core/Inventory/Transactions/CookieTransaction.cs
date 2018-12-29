using System;

namespace CookieApp.Core.Inventory
{
    public class CookieTransaction : Entity
    {
        protected CookieTransaction() { }
        public CookieTransaction( DateTime dateReceived) : this()
        {
            DateEntered = DateTime.UtcNow;
            DateReceived = dateReceived.ToUniversalTime();
        }

        public virtual DateTime DateEntered { get; }
        public virtual DateTime DateReceived { get; }

    }
}