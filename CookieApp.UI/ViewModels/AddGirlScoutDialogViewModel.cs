using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace CookieApp.UI.ViewModels
{
    public class AddGirlScoutDialogViewModel : ViewModelBase, IModalDialogViewModel
    {
        private bool? _dialogResult;
        private string _firstName;
        private string _lastName;
        private string _parentFirstName;
        private string _parentLastName;
        private string _phoneNumber;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand(OnSave));

        private void OnSave()
        {
            DialogResult = true;
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(OnCancel));

        private void OnCancel()
        {

            DialogResult = false;
        }

        public bool? DialogResult
        {
            get { return _dialogResult; }
            private set
            {
                if (value == _dialogResult) return;
                _dialogResult = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value == _firstName) return;
                _firstName = value;
                OnPropertyChanged();
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
            }
        }

        public string ParentFirstName
        {
            get { return _parentFirstName; }
            set
            {
                if (value == _parentFirstName) return;
                _parentFirstName = value;
                OnPropertyChanged();
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
            }
        }

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