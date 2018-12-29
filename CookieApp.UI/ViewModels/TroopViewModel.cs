﻿using System.Collections.ObjectModel;
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
        private ObservableCollection<GirlScoutViewModel> _girlScouts;
        private string _name;

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

        public ICommand AddGirlScoutCommand =>
            _addGirlScoutCommand ?? (_addGirlScoutCommand = new RelayCommand(AddGirlScout));

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

        private ICommand _addGirlScoutCommand;
        private readonly CookieAppApi _api;
        private readonly DialogService _dialogService;
        private int _troopId;
        private TroopInventoryViewModel _inventory;
        private GirlScoutViewModel _selectedGirlScout;

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
    }
}