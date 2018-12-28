using CookieApp.Core.Inventory;
using FluentNHibernate.Mapping;

namespace CookieApp.SqlLiteDatabase.Mappings
{
    public class GirlScoutCookieInventoryMap : SubclassMap<GirlScoutCookieInventory>
    {
        public GirlScoutCookieInventoryMap()
        {
            DiscriminatorValue(nameof(GirlScoutCookieInventory));
        }
    }
}