
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

        //todo move to di container
        public CookieAppApi(SessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        private IUnitOfWork unitOfWork => new UnitOfWork(_sessionFactory);

        public void AddCookiesFromCupboard(IEnumerable<CookieQuantity> cookies, DateTime dateReceived,
            int troopInventoryId)
        {
            var command = new AddCookiesFromCupboardCommand(cookies, dateReceived, troopInventoryId);
            var handler = new AddCookiesFromCupboardCommandHandler(unitOfWork);
        }

        public TroopDto GetTroopById(int id)
        {
            var command = new GetTroopQuery(id);
            var handler = new GetTroopQueryHandler(unitOfWork);
            return handler.Handle(command);
        }
    }
}