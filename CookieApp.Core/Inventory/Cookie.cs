using System.Collections.Generic;

namespace CookieApp.Core.Inventory
{
    public class Cookie : ValueObject
    {
        public virtual CookieVariety Variety { get; }
        public virtual decimal Price { get; }

        private Cookie()
        {
            
        }

        internal Cookie(CookieVariety variety, decimal price) : this()
        {
            Variety = variety;
            Price = price;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Variety;
            yield return Price;
        }

        public static Cookie DosiSo => new Cookie(CookieVariety.DoSiDos, 5m);
        public static Cookie Smors => new Cookie(CookieVariety.Smors, 6m);
        public static Cookie ThinMints => new Cookie(CookieVariety.ThinMints, 5m);
        public static Cookie Samoas => new Cookie(CookieVariety.Samoas, 5m);
        public static Cookie Tagalongs => new Cookie(CookieVariety.Tagalongs, 5m);
        public static Cookie Trefoils => new Cookie(CookieVariety.Trefoils, 5m);
        public static Cookie Savannah => new Cookie(CookieVariety.Savannah, 5m);
        public static Cookie ToffeeTastic => new Cookie(CookieVariety.ToffeeTastic, 6m);
    }
}