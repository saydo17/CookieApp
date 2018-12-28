﻿using System;
using System.Collections.Generic;

namespace CookieApp.Core.Inventory
{
    public class UpdateCookiesTransaction : Transaction
    {
        public virtual IEnumerable<CookieQuantity> Cookies { get; }

        protected UpdateCookiesTransaction()
        {
            
        }
        public UpdateCookiesTransaction(IEnumerable<CookieQuantity> cookies, DateTime dateReceived) : base(dateReceived)
        {
            Cookies = cookies;
        }
    }
}