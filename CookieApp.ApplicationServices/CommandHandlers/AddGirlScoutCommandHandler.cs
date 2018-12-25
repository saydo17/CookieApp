using CookieApp.Core;
using CookieApp.Core.AppServices;
using CookieApp.Core.Inventory;
using CookieApp.DataAccess.Repositories;
using CSharpFunctionalExtensions;

namespace CookieApp.ApplicationServices.CommandHandlers
{
    public class AddGirlScoutCommandHandler : ICommandHandler<AddGirlScoutCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddGirlScoutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(AddGirlScoutCommand command)
        {
            var repository = new TroopRepository(_unitOfWork);
            var troop = repository.GetTroop(command.TroopId);
            if (troop == null)
                return Result.Fail($"No troop with Id: {command.TroopId}");

            var girlScout = new GirlScout
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Inventory = new GirlScoutCookieInventory(),
                ParentFirstName = command.ParentFirstName,
                ParentLastName = command.ParentLastName,
                PhoneNumber = command.PhoneNumber
            };

            troop.AddGirlScout(girlScout);

            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}