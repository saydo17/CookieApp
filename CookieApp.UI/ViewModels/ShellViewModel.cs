namespace CookieApp.UI.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        public ShellViewModel()
        {
            CurrentViewModel = new TroopViewModel();
        }

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (Equals(value, _currentViewModel)) return;
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }
    }
}