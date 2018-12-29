using System;
using System.Collections.Generic;
using System.Linq;
using CookieApp.Core;
using CookieApp.Core.AppServices;
using CookieApp.Core.Inventory;
using CookieApp.DataAccess.Repositories;
using CookieApp.Dtos;

namespace CookieApp.ApplicationServices
{
    public class GetTroopQueryHandler : IQueryHandler<GetTroopQuery, TroopDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTroopQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TroopDto Handle(GetTroopQuery query)
        {
            var repository = new TroopRepository(_unitOfWork);

            var troop = repository.GetTroop(query.Id);
            return new TroopDto
            {
                Id = troop.Id,
                GirlScouts = troop.GirlScouts.Select(g => new GirlScoutDto
                {
                    FirstName = g.FirstName,
                    LastName = g.LastName,
                    ParentFirstName = g.ParentFirstName,
                    ParentLastName = g.ParentLastName,
                    PhoneNumber = g.PhoneNumber,
                    Inventory = CreateInventoryDto(g.Inventory)
                }).ToList(),
                Name = troop.Name,
                Inventory = CreateInventoryDto(troop.Inventory)
            };
        }

        private static InventoryDto CreateInventoryDto(CookieInventory inventory)
        {
            var dto = new InventoryDto
            {
                Id = inventory.Id,
                Balance = inventory.Balance,
                CookieSlots = inventory.Stacks.Select(s => new CookieSlotDto
                {
                    Position = s.Position,
                    CookieQuantity = new CookieQuantityDto
                    {
                        Quantity = s.CookieQuantity.Quantity,
                        Cookie = new CookieDto
                        {
                            CookieVariety = s.CookieQuantity.Cookie.Variety.ToString(),
                            Price = s.CookieQuantity.Cookie.Price
                        }
                    }
                }).ToList(),
                Transactions = inventory.Transactions
                    .Select(CookieTransactionDtoFactory.CreateCookieTransaction).ToList()
            };
            return dto;
        }
    }

    public static class CookieTransactionDtoFactory
    {
        public static CookieTransactionDto CreateCookieTransaction(CookieTransaction cookieTransaction)
        {
            CookieTransactionDto ret = null;
            var typeSwitch = new TypeSwitch()
                .Case((OrderTransaction x) => ret = new OrderTransactionDto()
                {
                    Cookies = x.Cookies.Select(c =>
                        new CookieQuantityDto()
                        {
                            Cookie = new CookieDto()
                            {
                                CookieVariety = c.Cookie.Variety.ToString(),
                                Price = c.Cookie.Price
                            },
                            Quantity = c.Quantity,
                        }
                    ).ToList(),
                    DateEntered = x.DateEntered,
                    DateReceived = x.DateReceived
                })
                .Case((CookieTransferInTransaction x) => ret = new CookieTransferInTransactionDto()
                {
                    DateEntered = x.DateEntered,
                    DateReceived = x.DateReceived,
                    FromInventoryId = x.FromInventoryId,
                    Cookies = x.Cookies.Select(c =>
                        new CookieQuantityDto()
                        {
                            Cookie = new CookieDto()
                            {
                                CookieVariety = c.Cookie.Variety.ToString(),
                                Price = c.Cookie.Price
                            },
                            Quantity = c.Quantity,
                        }
                    ).ToList()
                })
                .Case((CookieTransferOutTransaction x) => ret = new CookieTransferOutTransactionDto()
                {
                    DateEntered = x.DateEntered,
                    DateReceived = x.DateReceived,
                    ToInventoryId = x.ToInventoryId,
                    Cookies = x.Cookies.Select(c =>
                        new CookieQuantityDto()
                        {
                            Cookie = new CookieDto()
                            {
                                CookieVariety = c.Cookie.Variety.ToString(),
                                Price = c.Cookie.Price
                            },
                            Quantity = c.Quantity,
                        }
                    ).ToList()
                })
                .Case((PaymentTransaction x) => ret = new PaymentTransactionDto()
                {
                    DateEntered = x.DateEntered,
                    DateReceived = x.DateReceived,
                    Amount = x.Amount,
                })
                .Case((UpdateCookiesTransaction x) => ret = new UpdateCookiesTransactionDto()
                {
                    DateEntered = x.DateEntered,
                    DateReceived = x.DateReceived,
                    Cookies = x.Cookies.Select(c =>
                        new CookieQuantityDto()
                        {
                            Cookie = new CookieDto()
                            {
                                CookieVariety = c.Cookie.Variety.ToString(),
                                Price = c.Cookie.Price
                            },
                            Quantity = c.Quantity,
                        }
                    ).ToList()
                });

            typeSwitch.Switch(cookieTransaction);
            return ret;
        }
    }

    public class TypeSwitch
    {
        private readonly Dictionary<Type, Action<object>> _matches = new Dictionary<Type, Action<object>>();

        public TypeSwitch Case<T>(Action<T> action)
        {
            _matches.Add(typeof(T), (x) => action((T) x));
            return this;
        }

        public void Switch(object x)
        {
            _matches[x.GetType()](x);
        }
    }
}