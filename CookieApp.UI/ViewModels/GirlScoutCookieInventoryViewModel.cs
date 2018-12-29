﻿using System.Collections.ObjectModel;
using System.Linq;
using CookieApp.Dtos;
using CookieApp.UI.API;
using MvvmDialogs;

namespace CookieApp.UI.ViewModels
{
    public class GirlScoutCookieInventoryViewModel : ViewModelBase
    {
        private readonly DialogService _dialogService;
        private readonly CookieAppApi _api;
        private ObservableCollection<CookieSlotViewModel> _cookieSlots;
        private decimal _balance;

        public GirlScoutCookieInventoryViewModel(InventoryDto inventory, DialogService dialogService, CookieAppApi api)
        {
            _dialogService = dialogService;
            _api = api;
            UpdateInventory(inventory);
        }

        private void UpdateInventory(InventoryDto inventory)
        {
            Balance = inventory.Balance;
            CookieSlots = new ObservableCollection<CookieSlotViewModel>(inventory.CookieSlots.Select(s => new CookieSlotViewModel(s)));
        }

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
    }
}