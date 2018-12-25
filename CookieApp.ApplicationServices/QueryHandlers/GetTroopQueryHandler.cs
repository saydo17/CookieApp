using System;
using System.Linq;
using CookieApp.Core;
using CookieApp.Core.AppServices;
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
            return new TroopDto()
            {
                Id = troop.Id,
                GirlScouts = troop.GirlScouts.Select(g => new GirlScoutDto()
                {
                    FirstName = g.FirstName,
                    LastName = g.LastName,
                    ParentFirstName = g.ParentFirstName,
                    ParentLastName = g.ParentLastName,
                    PhoneNumber = g.PhoneNumber
                }).ToList(),
                Name = troop.Name,
                Inventory = new InventoryDto()
                {
                    Balance = troop.Inventory.Balance,
                    CookieSlots = troop.Inventory.Stacks.Select(s => new CookieSlotDto()
                    {
                        Position = s.Position,
                        Cookie = new CookieDto()
                        {
                            CookieVariety = s.CookieQuantity.Cookie.Variety.ToString(),
                            Price = s.CookieQuantity.Cookie.Price,
                        },
                        Quantity = s.CookieQuantity.Quantity
                    }).ToList()
                }
            };
        }
    }
}