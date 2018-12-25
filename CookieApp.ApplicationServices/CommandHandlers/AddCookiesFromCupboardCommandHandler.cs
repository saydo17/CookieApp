using CookieApp.Core;
using CookieApp.Core.AppServices;
using CookieApp.Core.Inventory;
using CookieApp.DataAccess.Repositories;
using CSharpFunctionalExtensions;

namespace CookieApp.ApplicationServices.CommandHandlers
{
    public class AddCookiesFromCupboardCommandHandler : ICommandHandler<AddCookiesFromCupboardCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCookiesFromCupboardCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(AddCookiesFromCupboardCommand command)
        {
            var repository = new InventoryRepository(_unitOfWork);

            var inventory = repository.GetById<TroopCookieInventory>(command.TroopInventoryId);
            if (inventory == null)
                return Result.Fail($"No Troop inventory found with Id: {command.TroopInventoryId}");

            inventory.AddCookiesFromCupboard(command.Cookies, command.DateReceived);

            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}