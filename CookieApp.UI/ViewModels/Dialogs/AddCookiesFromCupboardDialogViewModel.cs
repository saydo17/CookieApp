using System;

namespace CookieApp.UI.ViewModels
{
    public class AddCookiesFromCupboardDialogViewModel : DialogViewModelBase
    {
        private int _smors;
        private int _thinMints;
        private int _samoas;
        private int _tagalongs;
        private int _trefoils;
        private int _doSiSos;
        private int _savannah;
        private int _toffeeTastic;

        private DateTime _dateReceived;

        public AddCookiesFromCupboardDialogViewModel()
        {
            DateReceived = DateTime.Today;
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