using System;

namespace CookieApp.Core.Inventory
{
    public abstract class Transaction : Entity
    {
        protected Transaction() { }
        public Transaction( DateTime dateReceived) : this()
        {
            DateEntered = DateTime.UtcNow;
            DateReceived = dateReceived;
        }

        public virtual DateTime DateEntered { get; }
        public virtual DateTime DateReceived { get; }
    }
}