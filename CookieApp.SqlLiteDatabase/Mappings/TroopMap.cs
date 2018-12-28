using CookieApp.Core;
using FluentNHibernate.Mapping;

namespace CookieApp.SqlLiteDatabase.Mappings
{
    public class TroopMap : ClassMap<Troop>
    {
        public TroopMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.GirlScouts).Cascade.AllDeleteOrphan();
            References(x => x.Inventory).Cascade.All();
        }
        
    }
}