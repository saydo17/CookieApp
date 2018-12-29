using System;

namespace CookieApp.UI.ViewModels
{
    public class MakePaymentDialogViewModel : DialogViewModelBase
    {
        private decimal _amount;
        private DateTime _dateReceived;

        public MakePaymentDialogViewModel()
        {
            DateReceived = DateTime.Today;
        }

        protected override bool CanSave()
        {
            return Amount > 0;
        }

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (value == _amount) return;
                _amount = value;
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