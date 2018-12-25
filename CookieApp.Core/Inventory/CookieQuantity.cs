using System;
using System.Collections.Generic;

namespace CookieApp.Core.Inventory
{
    public class CookieQuantity : ValueObject
    {
        public CookieQuantity()
        {
            
        }
        public CookieQuantity(int quantity, Cookie cookie) : this()
        {
            Quantity = quantity;
            Cookie = cookie;
        }

        public virtual int Quantity { get; }
        public virtual Cookie Cookie { get; }

        public decimal TotalAmount => Quantity * Cookie.Price;

        public static CookieQuantity operator+ (CookieQuantity a, CookieQuantity b)
        {
            if (a.Cookie != b.Cookie)
            {
                throw new ArithmeticException("Cannot add different types or unequal unit costs");
            }

            return new CookieQuantity(a.Quantity + b.Quantity, a.Cookie);
        }

        public static CookieQuantity operator -(CookieQuantity a, CookieQuantity b)
        {
            if (a.Cookie != b.Cookie)
            {
                throw new ArithmeticException("Cannot subtract different types or unequal unit costs");
            }
            return new CookieQuantity(a.Quantity - b.Quantity, a.Cookie);
        }

        public static explicit operator CookieQuantity(string cookieQuantity)
        {
             var strings = cookieQuantity.Split('|');
            return new CookieQuantity(Convert.ToInt32(strings[2]),
                new Cookie((CookieVariety) Enum.Parse(typeof(CookieVariety), strings[0]),
                    Convert.ToDecimal(strings[1])));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Quantity;
            yield return Cookie;
        }

        public static explicit operator string(CookieQuantity cookieQuantity)
        {
            return $"{cookieQuantity.Cookie.Variety}|{cookieQuantity.Cookie.Price}|{cookieQuantity.Quantity}";
        }
    }
}