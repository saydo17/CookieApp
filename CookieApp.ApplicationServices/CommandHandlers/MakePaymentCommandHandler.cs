using CookieApp.Core;
using CookieApp.Core.AppServices;
using CookieApp.Core.Inventory;
using CookieApp.DataAccess.Repositories;
using CSharpFunctionalExtensions;

namespace CookieApp.ApplicationServices.CommandHandlers
{
    public class MakePaymentCommandHandler : ICommandHandler<MakePaymentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public MakePaymentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(MakePaymentCommand command)
        {
            var repository = new InventoryRepository(_unitOfWork);
            var inventory = repository.GetById<GirlScoutCookieInventory>(command.InventoryId);
            if (inventory == null)
                return Result.Fail($"No inventory fount with ID: {command.InventoryId}");

            inventory.MakePayment(command.Amount, command.DateReceived);

            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}