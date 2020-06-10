using MySql.Data.MySqlClient;
using System.Collections.Specialized;
using System.IO.Packaging;
using System.Windows.Input;
using System.Windows.Navigation;

namespace InteligentnyPosrednikNieruchomosci.Views
{
    internal class RegistrationViewModel
    {

        private NavigationService _navigationService;
        public ICommand Rejestracja { get; set; }
        public ICommand Cofnij { get; set; }

        public RegistrationViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            Rejestracja = new RelayCommand(CofnijMethod);
            //using (MySqlConnection )
        }


        private void CofnijMethod()
        {
            //MySqlConnection connection = new MySqlConnection(connectionString)
            _navigationService.GoBack();
        }

    }
}