using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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

        //need json attributes and private setters for transaction serialization
        [JsonProperty]
        public virtual int Quantity { get; private set; }
        [JsonProperty]
        public virtual Cookie Cookie { get; private set; }

        [JsonIgnore]
        public decimal TotalAmount => Cookie == null ? 0m : Quantity * Cookie.Price;

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