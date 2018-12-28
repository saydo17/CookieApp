using CookieApp.Core.Inventory;
using FluentNHibernate.Mapping;

namespace CookieApp.SqlLiteDatabase.Mappings
{
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
}