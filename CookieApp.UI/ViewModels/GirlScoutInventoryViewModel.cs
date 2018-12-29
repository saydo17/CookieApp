using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CookieApp.Dtos;
using CookieApp.UI.API;
using GalaSoft.MvvmLight.CommandWpf;
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
        private ICommand _makePaymentCommand;

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
                OnPropertyChanged(nameof(Value));
                OnPropertyChanged(nameof(Variance));
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
                OnPropertyChanged(nameof(Value));
                OnPropertyChanged(nameof(Variance));
            }
        }

        public decimal Value => CookieSlots.Sum(x => x.Quantity * x.Price);
        public decimal Variance => Balance - Value;

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

        public ICommand MakePaymentCommand => _makePaymentCommand ?? (_makePaymentCommand = new RelayCommand(MakePayment));

        private void MakePayment()
        {
            var viewModel = new MakePaymentDialogViewModel();
            var result = _dialogService.ShowDialog(this, viewModel);
            if (result.HasValue && result.Value)
            {
                _api.MakePayment(new MakePaymentDto()
                {
                    InventoryId = Id,
                    Amount = viewModel.Amount,
                    DateReceived = viewModel.DateReceived
                });
                var inventory = _api.GetGirlScoutInventoryById(Id);
                UpdateInventory(inventory);
            }
        }
    }
}