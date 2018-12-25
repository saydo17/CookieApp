using CookieApp.Core;
using CookieApp.Core.Inventory;

namespace CookieApp.DataAccess.Repositories
{
    public class InventoryRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TInventory GetById<TInventory>(int id)
        {
            return _unitOfWork.Get<TInventory>(id);
        }

        
    }
}