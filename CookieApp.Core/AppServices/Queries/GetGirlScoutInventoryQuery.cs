using CookieApp.Dtos;

namespace CookieApp.Core.AppServices
{
    public class GetGirlScoutInventoryQuery : IQuery<InventoryDto>
    {
        public GetGirlScoutInventoryQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}