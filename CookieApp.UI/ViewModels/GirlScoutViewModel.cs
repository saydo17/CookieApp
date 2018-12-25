namespace CookieApp.UI.ViewModels
{
    public class GirlScoutViewModel : ViewModelBase
    {
        private string _firstName;
        private string _lastName;
        private string _parentFirstName;
        private string _parentLastName;
        private string _phoneNumber;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value == _firstName) return;
                _firstName = value;
                OnPropertyChanged();
                OnPropertyChanged(FullName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value == _lastName) return;
                _lastName = value;
                OnPropertyChanged();
                OnPropertyChanged(FullName);
            }
        }

        public string FullName => $"{FirstName} {LastName}";

        public string ParentFirstName
        {
            get { return _parentFirstName; }
            set
            {
                if (value == _parentFirstName) return;
                _parentFirstName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ParentFullName));
            }
        }

        public string ParentLastName
        {
            get { return _parentLastName; }
            set
            {
                if (value == _parentLastName) return;
                _parentLastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ParentFullName));
            }
        }

        public string ParentFullName => $"{ParentFirstName} {ParentLastName}";

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value == _phoneNumber) return;
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }
    }
}