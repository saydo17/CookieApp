using CookieApp.Core.Inventory;

namespace CookieApp.Core
{
    public class GirlScout : Entity
    {
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string ParentFirstName { get; set; }
        public virtual string ParentLastName { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual GirlScoutCookieInventory Inventory { get; set; }


    }
}