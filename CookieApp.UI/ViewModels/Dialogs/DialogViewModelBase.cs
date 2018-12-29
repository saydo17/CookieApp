using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace CookieApp.UI.ViewModels
{
    public abstract class DialogViewModelBase : ViewModelBase, IModalDialogViewModel
    {
        private bool? _dialogResult;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;
        public bool? DialogResult
        {
            get { return _dialogResult; }
            protected set
            {
                if (value == _dialogResult) return;
                _dialogResult = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand(Save, CanSave));

        protected virtual bool CanSave()
        {
            return true;
        }

        protected virtual void Save()
        {
            DialogResult = true;
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(Cancel, CanCancel));

        protected virtual bool CanCancel()
        {
            return true;
        }

        protected virtual void Cancel()
        {
            DialogResult = false;
        }
    }
}