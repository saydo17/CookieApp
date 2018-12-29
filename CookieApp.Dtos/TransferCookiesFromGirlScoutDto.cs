using System;

namespace CookieApp.Dtos
{
    public class TransferCookiesFromGirlScoutDto
    {
        public int DoSiSos { get; set; }
        public int Samoas { get; set; }
        public int Savannah { get; set; }
        public int Smors { get; set; }
        public int Tagalongs { get; set; }
        public int ThinMints { get; set; }
        public int ToffeeTastic { get; set; }
        public int Trefoils { get; set; }
        public DateTime DateReceived { get; set; }
        public int TroopInventoryId { get; set; }
        public int GirlScoutInventoryId { get; set; }
    }
}