using System.Collections.ObjectModel;
using System.Linq;
using CookieApp.Dtos;
using CookieApp.UI.API;
using MvvmDialogs;

namespace CookieApp.UI.ViewModels
{
    public class GirlScoutInventoryViewModel : ViewModelBase
    {
        private readonly DialogService _dialogService;
        private readonly CookieAppApi _api;
        private ObservableCollection<CookieSlotViewModel> _cookieSlots;
        private decimal _balance;
        private string _girlsName;

        public GirlScoutInventoryViewModel(GirlScoutDto girlScout, DialogService dialogService, CookieAppApi api)
        {
            _dialogService = dialogService;
            _api = api;
            Id = girlScout.Inventory.Id;
            GirlsName = girlScout.FirstName;
            UpdateInventory(girlScout.Inventory);
        }

        public void UpdateInventory(InventoryDto inventory)
        {
            Balance = inventory.Balance;
            CookieSlots = new ObservableCollection<CookieSlotViewModel>(inventory.CookieSlots.Select(s => new CookieSlotViewModel(s)));
        }

        public int Id { get; }

        public ObservableCollection<CookieSlotViewModel> CookieSlots
        {
            get { return _cookieSlots; }
            set
            {
                if (Equals(value, _cookieSlots)) return;
                _cookieSlots = value;
                OnPropertyChanged();
            }
        }

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value == _balance) return;
                _balance = value;
                OnPropertyChanged();
            }
        }

        public string GirlsName
        {
            get { return _girlsName; }
            set
            {
                if (value == _girlsName) return;
                _girlsName = value;
                OnPropertyChanged();
            }
        }
    }
}