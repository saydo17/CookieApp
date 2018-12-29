using System.Linq;
using CookieApp.Core;
using CookieApp.Core.AppServices;
using CookieApp.Core.Inventory;
using CookieApp.DataAccess.Repositories;
using CookieApp.Dtos;

namespace CookieApp.ApplicationServices
{
    public class GetGirlScoutInventoryQueryHandler : IQueryHandler<GetGirlScoutInventoryQuery, InventoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGirlScoutInventoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public InventoryDto Handle(GetGirlScoutInventoryQuery query)
        {
            var repository = new InventoryRepository(_unitOfWork);
            var inventory = repository.GetById<GirlScoutCookieInventory>(query.Id);
            var inventoryDto = new InventoryDto
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
                Transactions = inventory.Transactions.Select(CookieTransactionDtoFactory.CreateCookieTransaction)
                    .ToList()
            };
            return inventoryDto;
        }
    }
}