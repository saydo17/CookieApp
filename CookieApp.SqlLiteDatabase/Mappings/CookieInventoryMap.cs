using CookieApp.Core.Inventory;
using FluentNHibernate.Mapping;

namespace CookieApp.SqlLiteDatabase.Mappings
{
    public class CookieInventoryMap : ClassMap<CookieInventory>
    {
        public CookieInventoryMap()
        {
            Id(x => x.Id);
            Map(x => x.Balance);
            HasMany(x => x.Stacks).Cascade.AllDeleteOrphan();
            HasMany(x => x.Transactions).Cascade.AllDeleteOrphan();
            DiscriminateSubClassesOnColumn("type");
        }
    }
}