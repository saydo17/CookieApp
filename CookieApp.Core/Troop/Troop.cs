using System.Collections.Generic;
using CookieApp.Core.Inventory;

namespace CookieApp.Core
{
    public class Troop : Entity
    {
        public Troop()
        {
            GirlScouts = new List<GirlScout>();
        }
        

        public virtual string Name { get; set; }
        public virtual IList<GirlScout> GirlScouts { get; set; }

        public virtual TroopCookieInventory Inventory { get; set; }

        public virtual void AddGirlScout(GirlScout girlScout)
        {
            GirlScouts.Add(girlScout);
        }


    }
}