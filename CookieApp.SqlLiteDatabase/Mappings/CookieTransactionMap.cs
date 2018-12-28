using System.Collections.Generic;
using System.Data;
using CookieApp.Core.Inventory;
using FluentNHibernate.Mapping;

namespace CookieApp.SqlLiteDatabase.Mappings
{
    public class CookieTransactionMap : ClassMap<CookieTransaction>
    {
        public CookieTransactionMap()
        {
            Id(x => x.Id);
            Map(x => x.DateEntered);
            Map(x => x.DateReceived);
            DiscriminateSubClassesOnColumn("type");
        }
    }

    public class CookieTransferInTransactionMap : SubclassMap<CookieTransferInTransaction>
    {
        public CookieTransferInTransactionMap()
        {
            DiscriminatorValue(nameof(CookieTransferInTransaction));
            Map(x => x.Cookies).CustomType<Blobbed<List<CookieQuantity>>>();
            Map(x => x.FromInventoryId);
        }
    }

    public class CookieTransferOutTransactionMap : SubclassMap<CookieTransferOutTransaction>
    {
        public CookieTransferOutTransactionMap()
        {
            DiscriminatorValue(nameof(CookieTransferOutTransaction));
            Map(x => x.Cookies).CustomType<Blobbed<List<CookieQuantity>>>();
            Map(x => x.ToInventoryId);
        }
    }

    public class OrderTransactionMap : SubclassMap<OrderTransaction>
    {
        public OrderTransactionMap()
        {
            DiscriminatorValue(nameof(OrderTransaction));
            Map(x => x.Cookies).CustomType<Blobbed<List<CookieQuantity>>>();
        }
    }

    public class PaymentTransactionMap : SubclassMap<PaymentTransaction>
    {
        public PaymentTransactionMap()
        {
            DiscriminatorValue(nameof(PaymentTransaction));
            Map(x => x.Amount);
        }
    }

    class UpdateCookieTransactionMap : SubclassMap<UpdateCookiesTransaction>
    {
        public UpdateCookieTransactionMap()
        {
            DiscriminatorValue(nameof(UpdateCookiesTransaction));
            Map(x => x.Cookies).CustomType<Blobbed<CookieQuantity>>();
        }
    }


}