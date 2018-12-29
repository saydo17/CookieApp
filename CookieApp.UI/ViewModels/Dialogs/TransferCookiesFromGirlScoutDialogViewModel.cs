using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace CookieApp.UI.ViewModels
{
    public class TransferCookiesFromGirlScoutDialogViewModel : DialogViewModelBase
    {
        private readonly GirlScoutInventoryViewModel _girlScoutInventory;
        private int _smors;
        private int _thinMints;
        private int _samoas;
        private int _tagalongs;
        private int _trefoils;
        private int _doSiSos;
        private int _savannah;
        private int _toffeeTastic;
        private DateTime _dateReceived;

        public TransferCookiesFromGirlScoutDialogViewModel(GirlScoutInventoryViewModel girlScoutInventory)
        {
            _girlScoutInventory = girlScoutInventory;
            _dateReceived = DateTime.Today;
        }

        //TODO Move to validation
        protected override bool CanSave()
        {
            foreach (var cookieSlot in _girlScoutInventory.CookieSlots)
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

            return Smors > 0 &&
                ThinMints > 0 &&
                Samoas > 0 &&
                Tagalongs > 0 &&
                Trefoils > 0 &&
                DoSiSos > 0 &&
                Savannah > 0 &&
                ToffeeTastic > 0;
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