using System.Collections.Generic;

namespace CookieApp.Dtos
{
    public class TroopDto
    {
        public string Name { get; set; }
        public List<GirlScoutDto> GirlScouts { get; set; }

        public InventoryDto Inventory { get; set; }
    }
}