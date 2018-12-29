
using System;
using System.Collections.Generic;
using CookieApp.ApplicationServices;
using CookieApp.ApplicationServices.CommandHandlers;
using CookieApp.Core;
using CookieApp.Core.AppServices;
using CookieApp.Core.Inventory;
using CookieApp.Dtos;
using CookieApp.SqlLiteDatabase;
using CookieApp.UI.ViewModels;

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

        public void AddCookiesFromCupboard(AddCookiesFromCupboardDto data)
        {
            using (var uow = UnitOfWork)
            {
                //TODO convert dto
                IEnumerable<CookieQuantity> cookies = new[]
                {
                    new CookieQuantity(data.DoSiSos, Cookie.DosiSo),
                    new CookieQuantity(data.Samoas, Cookie.Samoas),
                    new CookieQuantity(data.Savannah, Cookie.Savannah),
                    new CookieQuantity(data.Smors, Cookie.Smors),
                    new CookieQuantity(data.Tagalongs, Cookie.Tagalongs),
                    new CookieQuantity(data.ThinMints, Cookie.ThinMints),
                    new CookieQuantity(data.ToffeeTastic, Cookie.ToffeeTastic),
                    new CookieQuantity(data.Trefoils, Cookie.Trefoils), 
                };
                DateTime dateReceived = data.DateReceived;
                int troopInventoryId = data.TroopInventoryId;


                var command = new AddCookiesFromCupboardCommand(cookies, dateReceived, troopInventoryId);
                var handler = new AddCookiesFromCupboardCommandHandler(uow);
                var result = handler.Handle(command);
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

        public void AddGirlScoutToTroop(NewGirlScoutDto girlScout, int troopId)
        {
            using (var uow = UnitOfWork)
            {
                var command = new AddGirlScoutCommand(girlScout.FirstName, girlScout.LastName, girlScout.ParentFirstName,
                    girlScout.ParentLastName, girlScout.PhoneNumber, troopId);
                var handler = new AddGirlScoutCommandHandler(uow);
                var result = handler.Handle(command);
            }
        }

        public InventoryDto GetTroopInventoryById(int id)
        {
            using (var uow = UnitOfWork)
            {
                var command = new GetTroopInventoryQuery(id);
                var handler = new GetTroopInventoryQueryHandler(uow);
                return handler.Handle(command);
            }
        }

        public InventoryDto GetGirlScoutInventoryById(int id)
        {
            using (var uow = UnitOfWork)
            {
                var command = new GetGirlScoutInventoryQuery(id);
                var handler = new GetGirlScoutInventoryQueryHandler(uow);
                return handler.Handle(command);
            }
        }

        public void TransferCookiesFromTroopToGirlScout(TransferCookiesToGirlScoutDto data)
        {
            using (var uow = UnitOfWork)
            {
                //TODO convert dto
                IEnumerable<CookieQuantity> cookies = new[]
                {
                    new CookieQuantity(data.DoSiSos, Cookie.DosiSo),
                    new CookieQuantity(data.Samoas, Cookie.Samoas),
                    new CookieQuantity(data.Savannah, Cookie.Savannah),
                    new CookieQuantity(data.Smors, Cookie.Smors),
                    new CookieQuantity(data.Tagalongs, Cookie.Tagalongs),
                    new CookieQuantity(data.ThinMints, Cookie.ThinMints),
                    new CookieQuantity(data.ToffeeTastic, Cookie.ToffeeTastic),
                    new CookieQuantity(data.Trefoils, Cookie.Trefoils),
                };
                DateTime dateReceived = data.DateReceived;
                int troopInventoryId = data.TroopInventoryId;
                int girlScoutInventoryId = data.GirlScoutInventoryId;


                var command = new TransferCookiesCommand(troopInventoryId, girlScoutInventoryId,cookies, dateReceived);
                var handler = new TransferCookiesCommandHandler(uow);
                var result = handler.Handle(command);
            }
        }

        public void TransferCookiesFromGirlScoutToTroop(TransferCookiesFromGirlScoutDto data)
        {
            using (var uow = UnitOfWork)
            {
                //TODO convert dto
                IEnumerable<CookieQuantity> cookies = new[]
                {
                    new CookieQuantity(data.DoSiSos, Cookie.DosiSo),
                    new CookieQuantity(data.Samoas, Cookie.Samoas),
                    new CookieQuantity(data.Savannah, Cookie.Savannah),
                    new CookieQuantity(data.Smors, Cookie.Smors),
                    new CookieQuantity(data.Tagalongs, Cookie.Tagalongs),
                    new CookieQuantity(data.ThinMints, Cookie.ThinMints),
                    new CookieQuantity(data.ToffeeTastic, Cookie.ToffeeTastic),
                    new CookieQuantity(data.Trefoils, Cookie.Trefoils),
                };
                DateTime dateReceived = data.DateReceived;
                int troopInventoryId = data.TroopInventoryId;
                int girlScoutInventoryId = data.GirlScoutInventoryId;


                var command = new TransferCookiesCommand(girlScoutInventoryId, troopInventoryId, cookies, dateReceived);
                var handler = new TransferCookiesCommandHandler(uow);
                var result = handler.Handle(command);
            }
        }
    }
}