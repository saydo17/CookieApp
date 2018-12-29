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
        private string _troopName;

        public TroopInventoryViewModel(TroopDto troop, IDialogService dialogService, CookieAppApi api)
        {
            _dialogService = dialogService;
            _api = api;
            _inventoryId = troop.Inventory.Id;
            TroopName = troop.Name;
            UpdateInventory(troop.Inventory);
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

        public string TroopName
        {
            get { return _troopName; }
            set
            {
                if (value == _troopName) return;
                _troopName = value;
                OnPropertyChanged();
            }
        }

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
}