using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CookieApp.Dtos;
using CookieApp.SqlLiteDatabase;
using CookieApp.UI.API;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace CookieApp.UI.ViewModels
{
    public class TroopViewModel : ViewModelBase
    {
        private readonly CookieAppApi _api;
        private readonly DialogService _dialogService;
        private int _troopId;
        private string _name;
        private TroopInventoryViewModel _inventory;
        private ObservableCollection<GirlScoutViewModel> _girlScouts;
        private GirlScoutViewModel _selectedGirlScout;
        private ICommand _addGirlScoutCommand;
        private ICommand _transferCookiesToGirlScoutCommand;
        private ICommand _transferCookiesFromGirlScoutCommand;

        public TroopViewModel()
        {
            //TODO DI
            _dialogService = new DialogService();
            _api = new CookieAppApi(new SessionFactory("Test.db"));
            GetTroop();
        }

        private void GetTroop()
        {
            var troop = _api.GetTroopById(1);
            _troopId = troop.Id;
            Name = troop.Name;
            GirlScouts = new ObservableCollection<GirlScoutViewModel>(troop.GirlScouts.Select(g => new GirlScoutViewModel()
            {
                FirstName = g.FirstName,
                LastName = g.LastName,
                ParentFirstName = g.ParentFirstName,
                ParentLastName = g.ParentLastName,
                PhoneNumber = g.PhoneNumber,
                //TODO Factory for DI
                Inventory = new GirlScoutInventoryViewModel(g, _dialogService, _api)
            }));
            //TODO Factory for DI
            Inventory = new TroopInventoryViewModel(troop, _dialogService, _api);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public TroopInventoryViewModel Inventory
        {
            get { return _inventory; }
            set
            {
                if (Equals(value, _inventory)) return;
                _inventory = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<GirlScoutViewModel> GirlScouts
        {
            get { return _girlScouts; }
            set
            {
                if (Equals(value, _girlScouts)) return;
                _girlScouts = value;
                OnPropertyChanged();
            }
        }

        public GirlScoutViewModel SelectedGirlScout
        {
            get { return _selectedGirlScout; }
            set
            {
                if (Equals(value, _selectedGirlScout)) return;
                _selectedGirlScout = value;
                OnPropertyChanged();
            }
        }

        #region AddGirlScout

        public ICommand AddGirlScoutCommand =>
            _addGirlScoutCommand ?? (_addGirlScoutCommand = new RelayCommand(AddGirlScout));


        private void AddGirlScout()
        {
            var vm = new AddGirlScoutDialogViewModel();
            var result = _dialogService.ShowDialog(this, vm);

            if (result.HasValue && result.Value)
            {
                _api.AddGirlScoutToTroop(new NewGirlScoutDto()
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    ParentFirstName = vm.ParentFirstName,
                    ParentLastName = vm.ParentLastName,
                    PhoneNumber = vm.PhoneNumber
                }, _troopId);

                GetTroop();
            }
            
        }

        #endregion

        #region TransferCookiesToGirlScout

        public ICommand TransferCookiesToGirlScoutCommand => _transferCookiesToGirlScoutCommand ?? (_transferCookiesToGirlScoutCommand = new RelayCommand(TransferCookiesToGirlScout, CanTransferCookies));

        private void TransferCookiesToGirlScout()
        {
            var viewModel = new TransferCookiesToGirlScoutDialogViewModel(Inventory);
            var result = _dialogService.ShowDialog(this, viewModel);
            if (result.HasValue && result.Value)
            {
                var dto = new TransferCookiesToGirlScoutDto()
                {
                    DateReceived = viewModel.DateReceived,
                    DoSiSos = viewModel.DoSiSos,
                    GirlScoutInventoryId = SelectedGirlScout.Inventory.Id,
                    Savannah = viewModel.Savannah,
                    Samoas = viewModel.Samoas,
                    Smors = viewModel.Smors,
                    ThinMints = viewModel.ThinMints,
                    Tagalongs = viewModel.Tagalongs,
                    ToffeeTastic = viewModel.ToffeeTastic,
                    Trefoils = viewModel.Trefoils, 
                    TroopInventoryId = Inventory.Id
                };
                _api.TransferCookiesFromTroopToGirlScout(dto);
            }

            UpdateInventories();
        }

        #endregion

        #region TransferCookieFromGirlScout

        public ICommand TransferCookiesFromGirlScoutCommand =>
            _transferCookiesFromGirlScoutCommand ?? (_transferCookiesFromGirlScoutCommand =
                new RelayCommand(TransferCookiesFromGirlScout, CanTransferCookies));

        private void TransferCookiesFromGirlScout()
        {
            var viewModel = new TransferCookiesFromGirlScoutDialogViewModel(SelectedGirlScout.Inventory);
            var result = _dialogService.ShowDialog(this, viewModel);
            if (result.HasValue && result.Value)
            {
                var dto = new TransferCookiesFromGirlScoutDto()
                {
                    DateReceived = viewModel.DateReceived,
                    DoSiSos = viewModel.DoSiSos,
                    GirlScoutInventoryId = SelectedGirlScout.Inventory.Id,
                    Savannah = viewModel.Savannah,
                    Samoas = viewModel.Samoas,
                    Smors = viewModel.Smors,
                    ThinMints = viewModel.ThinMints,
                    Tagalongs = viewModel.Tagalongs,
                    ToffeeTastic = viewModel.ToffeeTastic,
                    Trefoils = viewModel.Trefoils,
                    TroopInventoryId = Inventory.Id
                };
                _api.TransferCookiesFromGirlScoutToTroop(dto);
            }

            UpdateInventories();
        }

        #endregion

        private bool CanTransferCookies()
        {
            return SelectedGirlScout != null;
        }
        private void UpdateInventories()
        {
            var inventory = _api.GetTroopInventoryById(Inventory.Id);
            Inventory.UpdateInventory(inventory);

            var girlScoutInventory = _api.GetGirlScoutInventoryById(SelectedGirlScout.Inventory.Id);
            SelectedGirlScout.Inventory.UpdateInventory(girlScoutInventory);
        }
    }
}