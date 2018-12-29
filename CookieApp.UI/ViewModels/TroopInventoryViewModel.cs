using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CookieApp.Dtos;
using CookieApp.UI.API;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace CookieApp.UI.ViewModels
{
    public class TroopInventoryViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly CookieAppApi _api;
        private decimal _balance;
        private ICommand _addCookiesFromCupboardCommand;
        private readonly int _inventoryId;

        public TroopInventoryViewModel(InventoryDto inventory, IDialogService dialogService, CookieAppApi api)
        {
            _dialogService = dialogService;
            _api = api;
            _inventoryId = inventory.Id;
            UpdateInventory(inventory);
        }

        private void UpdateInventory(InventoryDto inventory)
        {
            Balance = inventory.Balance;
            CookieSlots = new ObservableCollection<CookieSlotViewModel>(inventory.CookieSlots.Select(s => new CookieSlotViewModel(s)));
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

        public ObservableCollection<CookieSlotViewModel> CookieSlots { get; set; }

        public ICommand AddCookiesFromCupboardCommand => _addCookiesFromCupboardCommand ??
                                                         (_addCookiesFromCupboardCommand =
                                                             new RelayCommand(AddCookiesFromCupboard));

        private void AddCookiesFromCupboard()
        {
            var viewModel = new AddCookiesFromCupboardDialogViewModel();
            var result = _dialogService.ShowDialog(this, viewModel);

            if (!result.HasValue || !result.Value) return;

            var dto = new AddCookiesFromCupboardDto()
            {
                DateReceived = viewModel.DateReceived,
                DoSiSos = viewModel.DoSiSos,
                Savannah = viewModel.Savannah,
                Samoas = viewModel.Samoas,
                Smors = viewModel.Smors,
                Tagalongs = viewModel.Tagalongs,
                ThinMints = viewModel.ThinMints,
                ToffeeTastic = viewModel.ToffeeTastic,
                Trefoils = viewModel.Trefoils,
                TroopInventoryId = _inventoryId
            };
            _api.AddCookiesFromCupboard(dto);
            var inventory = _api.GetTroopInventoryById(_inventoryId);
            UpdateInventory(inventory);

        }
    }

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