namespace CookieApp.Core.AppServices
{
    public class AddGirlScoutCommand : ICommand
    {
        public AddGirlScoutCommand(string firstName, string lastName, string parentFirstName, string parentLastName, string phoneNumber, int troopId)
        {
            FirstName = firstName;
            LastName = lastName;
            ParentFirstName = parentFirstName;
            ParentLastName = parentLastName;
            PhoneNumber = phoneNumber;
            TroopId = troopId;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string ParentFirstName { get; }
        public string ParentLastName { get; }
        public string PhoneNumber { get; }
        public int TroopId { get; }
    }
}