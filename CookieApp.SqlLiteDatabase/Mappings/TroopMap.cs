using CookieApp.Core;
using CookieApp.Core.Inventory;
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

    public class GirlScoutMap : ClassMap<GirlScout>
    {
        public GirlScoutMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.ParentFirstName);
            Map(x => x.ParentLastName);
            Map(x => x.PhoneNumber);


            References(x => x.Inventory);
        }
    }

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

    public class TroopCookieInventoryMap : SubclassMap<TroopCookieInventory>
    {
        public TroopCookieInventoryMap()
        {
            DiscriminatorValue(nameof(TroopCookieInventory));
        }
    }

    public class GirlScoutCookieInventoryMap : SubclassMap<GirlScoutCookieInventory>
    {
        public GirlScoutCookieInventoryMap()
        {
            DiscriminatorValue(nameof(GirlScoutCookieInventory));
        }
    }

    public class CookieStackMap : ClassMap<CookieStack>
    {
        public CookieStackMap()
        {
            Id(x => x.Id);
            Map(x => x.Position);
            Component(x => x.CookieQuantity, cookieQuantity =>
            {
                cookieQuantity.Map(x => x.Quantity);
                cookieQuantity.Component(x => x.Cookie, cookie =>
                {
                    cookie.Map(x => x.Price);
                    cookie.Map(x => x.Variety);
                });
            });
        }
    }

    public class TranactionMap : ClassMap<Transaction>
    {
        public TranactionMap()
        {
            Id(x => x.Id);
            Map(x => x.DateEntered);
            Map(x => x.DateReceived);
            
        }
    }
}