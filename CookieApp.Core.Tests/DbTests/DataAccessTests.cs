﻿using System.Diagnostics.CodeAnalysis;
using CookieApp.Core.Inventory;
using CookieApp.SqlLiteDatabase;
using FluentAssertions;
using NHibernate;
using NUnit.Framework;

namespace CookieApp.Core.Tests.DbTests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class DataAccessTests
    {
        [Test]
        public void CreateDatabase()
        {
            SessionFactory.Init("c:\\Temp\\Test.db");

            using (ISession session = SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var Troop = new Troop()
                {
                    Name = "Test Troop",
                    Inventory = new TroopCookieInventory(),
                };
                session.SaveOrUpdate(Troop);
                transaction.Commit();
            }
        }
    }
}