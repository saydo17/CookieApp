using CookieApp.Core;

namespace CookieApp.DataAccess.Repositories
{
    public class TroopRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public TroopRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Troop GetTroop(int id)
        {
            return _unitOfWork.Get<Troop>(id);
        }
    }
}