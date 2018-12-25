using CookieApp.Core;
using CookieApp.Core.AppServices;
using CookieApp.Core.Inventory;
using CookieApp.DataAccess.Repositories;
using CSharpFunctionalExtensions;

namespace CookieApp.ApplicationServices.CommandHandlers
{
    public class TransferCookiesCommandHandler : ICommandHandler<TransferCookiesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransferCookiesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(TransferCookiesCommand command)
        {
            var repository = new InventoryRepository(_unitOfWork);

            var fromInventory = repository.GetById<CookieInventory>(command.FromInventoryId);
            if (fromInventory == null)
                return Result.Fail($"FromInventory: Could not find Inventory with Id: {command.FromInventoryId}");
            var toInventory = repository.GetById<CookieInventory>(command.ToInventoryId);
            if (toInventory == null)
                return Result.Fail($"ToInventory: Could not find Inventory with Id: {command.ToInventoryId}");


            fromInventory.TransferCookiesOut(command.Cookies, command.DateReceived, command.ToInventoryId);

            toInventory.TransferCookiesIn(command.Cookies, command.DateReceived, command.FromInventoryId);

            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}