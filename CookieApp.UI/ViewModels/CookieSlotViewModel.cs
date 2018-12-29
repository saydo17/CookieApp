using CookieApp.Dtos;

namespace CookieApp.UI.ViewModels
{
    public class CookieSlotViewModel : ViewModelBase
    {
        private string _variety;
        private decimal _price;
        private int _quantity;

        public string Variety
        {
            get { return _variety; }
            set
            {
                if (value == _variety) return;
                _variety = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value == _price) return;
                _price = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value == _quantity) return;
                _quantity = value;
                OnPropertyChanged();
            }
        }

        public CookieSlotViewModel(CookieSlotDto cookieSlotDto)
        {
            Variety = cookieSlotDto.Cookie.CookieVariety;
            Price = cookieSlotDto.Cookie.Price;
            Quantity = cookieSlotDto.Quantity;
        }
    }
}