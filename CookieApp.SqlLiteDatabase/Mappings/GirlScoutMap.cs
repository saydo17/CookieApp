using CookieApp.Core;
using FluentNHibernate.Mapping;

namespace CookieApp.SqlLiteDatabase.Mappings
{
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


            References(x => x.Inventory).Cascade.All();
        }
    }
}