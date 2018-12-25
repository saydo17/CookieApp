
using System;
using System.Collections.Generic;
using CookieApp.ApplicationServices;
using CookieApp.ApplicationServices.CommandHandlers;
using CookieApp.Core;
using CookieApp.Core.AppServices;
using CookieApp.Core.Inventory;
using CookieApp.Dtos;
using CookieApp.SqlLiteDatabase;

namespace CookieApp.UI.API
{
    public class CookieAppApi
    {
        private readonly SessionFactory _sessionFactory;

        public CookieAppApi(SessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        private IUnitOfWork UnitOfWork => new UnitOfWork(_sessionFactory);

        public void AddCookiesFromCupboard(IEnumerable<CookieQuantity> cookies, DateTime dateReceived,
            int troopInventoryId)
        {
            using (var uow = UnitOfWork)
            {
                var command = new AddCookiesFromCupboardCommand(cookies, dateReceived, troopInventoryId);
                var handler = new AddCookiesFromCupboardCommandHandler(uow);
            }
            
        }

        public TroopDto GetTroopById(int id)
        {
            using (var uow = UnitOfWork)
            {
                var command = new GetTroopQuery(id);
                var handler = new GetTroopQueryHandler(uow);
                return handler.Handle(command);
            }
            
        }

        public void AddGirlScoutToTroop(GirlScoutDto girlScout, int troopId)
        {
            using (var uow = UnitOfWork)
            {
                var command = new AddGirlScoutCommand(girlScout.FirstName, girlScout.LastName, girlScout.ParentFirstName,
                    girlScout.ParentLastName, girlScout.PhoneNumber, troopId);
                var handler = new AddGirlScoutCommandHandler(uow);
                var result = handler.Handle(command);
            }
        }
    }
}