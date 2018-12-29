using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace CookieApp.UI.ViewModels
{
    public class TransferCookiesToGirlScoutDialogViewModel : ViewModelBase, IModalDialogViewModel
    {
        private readonly TroopInventoryViewModel _troopInventory;
        private int _smors;
        private int _thinMints;
        private int _samoas;
        private int _tagalongs;
        private int _trefoils;
        private int _doSiSos;
        private int _savannah;
        private int _toffeeTastic;
        private DateTime _dateReceived;
        private bool? _dialogResult;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        public TransferCookiesToGirlScoutDialogViewModel(TroopInventoryViewModel troopInventory)
        {
            _troopInventory = troopInventory;
            _dateReceived = DateTime.Today;
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(Cancel));

        private void Cancel()
        {
            DialogResult = false;
        }

        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand(Save, CanSave));

        //TODO Move to validation
        private bool CanSave()
        {
            foreach (var cookieSlot in _troopInventory.CookieSlots)
            {
                if (cookieSlot.Variety == CookieVariety.Tagalongs.ToString())
                    if (cookieSlot.Quantity - Tagalongs < 0)
                        return false;
                if(cookieSlot.Variety == CookieVariety.DoSiDos.ToString())
                    if (cookieSlot.Quantity - DoSiSos < 0)
                        return false;
                if(cookieSlot.Variety == CookieVariety.Samoas.ToString())
                    if (cookieSlot.Quantity - Samoas < 0)
                        return false;
                if(cookieSlot.Variety == CookieVariety.Savannah.ToString())
                    if (cookieSlot.Quantity - Savannah < 0)
                        return false;
                if(cookieSlot.Variety == CookieVariety.Smors.ToString())
                    if (cookieSlot.Quantity - Smors < 0)
                        return false;
                if(cookieSlot.Variety == CookieVariety.ThinMints.ToString())
                    if (cookieSlot.Quantity - ThinMints < 0)
                        return false;

                if(cookieSlot.Variety == CookieVariety.ToffeeTastic.ToString())
                    if (cookieSlot.Quantity - ToffeeTastic < 0)
                        return false;
                if(cookieSlot.Variety == CookieVariety.Trefoils.ToString())
                    if (cookieSlot.Quantity - Trefoils < 0)
                        return false;

            }
            return true;
        }

        private void Save()
        {
            DialogResult = true;
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

        public int Smors
        {
            get { return _smors; }
            set
            {
                if (value == _smors) return;
                _smors = value;
                OnPropertyChanged();
            }
        }

        public int ThinMints
        {
            get { return _thinMints; }
            set
            {
                if (value == _thinMints) return;
                _thinMints = value;
                OnPropertyChanged();
            }
        }

        public int Samoas
        {
            get { return _samoas; }
            set
            {
                if (value == _samoas) return;
                _samoas = value;
                OnPropertyChanged();
            }
        }

        public int Tagalongs
        {
            get { return _tagalongs; }
            set
            {
                if (value == _tagalongs) return;
                _tagalongs = value;
                OnPropertyChanged();
            }
        }

        public int Trefoils
        {
            get { return _trefoils; }
            set
            {
                if (value == _trefoils) return;
                _trefoils = value;
                OnPropertyChanged();
            }
        }

        public int DoSiSos
        {
            get { return _doSiSos; }
            set
            {
                if (value == _doSiSos) return;
                _doSiSos = value;
                OnPropertyChanged();
            }
        }

        public int Savannah
        {
            get { return _savannah; }
            set
            {
                if (value == _savannah) return;
                _savannah = value;
                OnPropertyChanged();
            }
        }

        public int ToffeeTastic
        {
            get { return _toffeeTastic; }
            set
            {
                if (value == _toffeeTastic) return;
                _toffeeTastic = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateReceived
        {
            get { return _dateReceived; }
            set
            {
                if (value.Equals(_dateReceived)) return;
                _dateReceived = value;
                OnPropertyChanged();
            }
        }
    }
}