using CookieApp.Dtos;

namespace CookieApp.Core.AppServices
{
    public class GetTroopQuery : IQuery<TroopDto>
    {
        public GetTroopQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}