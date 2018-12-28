using CookieApp.Core.Inventory;
using FluentNHibernate.Mapping;

namespace CookieApp.SqlLiteDatabase.Mappings
{
    public class TroopCookieInventoryMap : SubclassMap<TroopCookieInventory>
    {
        public TroopCookieInventoryMap()
        {
            DiscriminatorValue(nameof(TroopCookieInventory));
        }
    }
}