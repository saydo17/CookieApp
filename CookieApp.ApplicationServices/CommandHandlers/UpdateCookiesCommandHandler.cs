using CookieApp.Core;
using CookieApp.Core.AppServices;
using CookieApp.Core.Inventory;
using CookieApp.DataAccess.Repositories;
using CSharpFunctionalExtensions;

namespace CookieApp.ApplicationServices.CommandHandlers
{
    public class UpdateCookiesCommandHandler : ICommandHandler<UpdateCookiesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCookiesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(UpdateCookiesCommand command)
        {
            var repository = new InventoryRepository(_unitOfWork);

            var inventory = repository.GetById<CookieInventory>(command.InventoryId);
            if (inventory == null)
                return Result.Fail($"No inventory found with Id: {command.InventoryId}");

            inventory.UpdateCookies(command.Cookies, command.DateReceived);

            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}