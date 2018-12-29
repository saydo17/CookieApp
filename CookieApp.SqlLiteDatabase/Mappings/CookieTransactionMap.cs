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
            Map(x => x.Cookies).CustomType<Blobbed<IEnumerable<CookieQuantity>>>()
                .Nullable();
            Map(x => x.FromInventoryId)
                .Nullable();
        }
    }

    public class CookieTransferOutTransactionMap : SubclassMap<CookieTransferOutTransaction>
    {
        public CookieTransferOutTransactionMap()
        {
            DiscriminatorValue(nameof(CookieTransferOutTransaction));
            Map(x => x.Cookies).CustomType<Blobbed<IEnumerable<CookieQuantity>>>()
                .Nullable();
            Map(x => x.ToInventoryId)
                .Nullable();
        }
    }

    public class OrderTransactionMap : SubclassMap<OrderTransaction>
    {
        public OrderTransactionMap()
        {
            DiscriminatorValue(nameof(OrderTransaction));
            Map(x => x.Cookies).CustomType<Blobbed<IEnumerable<CookieQuantity>>>()
                .Nullable();
        }
    }

    public class PaymentTransactionMap : SubclassMap<PaymentTransaction>
    {
        public PaymentTransactionMap()
        {
            DiscriminatorValue(nameof(PaymentTransaction));
            Map(x => x.Amount)
                .Nullable();
        }
    }

    class UpdateCookieTransactionMap : SubclassMap<UpdateCookiesTransaction>
    {
        public UpdateCookieTransactionMap()
        {
            DiscriminatorValue(nameof(UpdateCookiesTransaction));
            Map(x => x.Cookies).CustomType<Blobbed<IEnumerable<CookieQuantity>>>()
                .Nullable();
        }
    }


}