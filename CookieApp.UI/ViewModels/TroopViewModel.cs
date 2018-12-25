using System.Collections.ObjectModel;
using System.Linq;
using CookieApp.SqlLiteDatabase;
using CookieApp.UI.API;

namespace CookieApp.UI.ViewModels
{
    public class TroopViewModel : ViewModelBase
    {
        private ObservableCollection<GirlScoutViewModel> _girlScouts;
        private string _name;

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

        public TroopViewModel()
        {
            var api = new CookieAppApi(new SessionFactory("Test.db"));
            var troop = api.GetTroopById(1);
            Name = troop.Name;
            GirlScouts = new ObservableCollection<GirlScoutViewModel>(troop.GirlScouts.Select(g => new GirlScoutViewModel()
            {
                FirstName = g.FirstName,
                LastName = g.LastName,
                ParentFirstName = g.ParentFirstName,
                ParentLastName = g.ParentLastName,
                PhoneNumber = g.PhoneNumber,
            }));
        }
    }
}