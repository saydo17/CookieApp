using CookieApp.Dtos;

namespace CookieApp.Core.AppServices
{
    public class GetTroopInventoryQuery : IQuery<InventoryDto>
    {
        public GetTroopInventoryQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}