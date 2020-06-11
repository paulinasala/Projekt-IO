using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace InteligentnyPosrednikNieruchomosci
{
    internal class DodajOferteViewModel
    {
        private NavigationService _navigationService;
        public ICommand DodajOferte { get; set; }
        public ICommand Cofnij { get; set; }
        public Klient Zalogowany { get; set; }
        public string Dzielnica { get; set; }
        public string Adres { get; set; }
        public string Metraz { get; set; }
        public string LiczbaPomieszczen { get; set; }
        public string Pietro { get; set; }
        public string Cena { get; set; }
        public string Obiekty { get; set; }
        public string Opis { get; set; }
        public string Zdjecie { get; set; }
        public DodajOferteViewModel(NavigationService navigationService, Klient k)
        {
            _navigationService = navigationService;
            DodajOferte = new RelayCommand(DodajOferteMethodMethod);
            Cofnij = new RelayCommand(CofnijMethod);
            Zalogowany = k;

        }

        private void CofnijMethod()
        {
            _navigationService.GoBack();
        }

        private void DodajOferteMethodMethod()
        {
            if (string.IsNullOrEmpty(Dzielnica) || string.IsNullOrEmpty(Adres) || string.IsNullOrEmpty(Metraz) || string.IsNullOrEmpty(LiczbaPomieszczen) || string.IsNullOrEmpty(Pietro) || string.IsNullOrEmpty(Cena) || string.IsNullOrEmpty(Obiekty) || string.IsNullOrEmpty(Opis))
            {
                new AlertWindow("Wypełnij wszystkie pola!").Show();
                return;
            }
            if (!Int32.TryParse(LiczbaPomieszczen, out var pomieszczen))
            {
                new AlertWindow("Liczba pokoi musi być liczbą całkowitą").Show();
                return;
            }
            if (!Int32.TryParse(Pietro, out var pietro))
            {
                new AlertWindow("Piętro musi być liczbą całkowitą").Show();
                return;
            }
            if (!float.TryParse(Metraz, out var metraz))
            {
                new AlertWindow("Metraz musi być liczbą zmiennoprzecinkową").Show();
                return;
            }
            if (!float.TryParse(Cena, out var cena))
            {
                new AlertWindow("Cena musi być liczbą zmiennoprzecinkową").Show();
                return;
            }
            if(pomieszczen<=0 || metraz<=0 || cena <= 0)
            {
                new AlertWindow("Cena, liczba pokoi i metraz muszą być większe od 0").Show();
                return;
            }

            using (DbConnection connection = MySqlClientFactory.Instance.CreateConnection())
            {
                var str = "Data Source=posrednik.czgecepfvj6q.eu-central-1.rds.amazonaws.com;Initial Catalog=posrednik_nieruchomosci;User ID=admin; Password=projektio20;";

                connection.ConnectionString = str;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO oferta VALUES(null, \"{Zalogowany.IdKlienta}\",\"{Adres}\",\"{Dzielnica}\",\"{metraz}\",\"{pomieszczen}\",\"{pietro}\",\"{Cena}\",\"{Obiekty}\",\"{cena}\",\"url\")";
                command.ExecuteNonQuery();
                new AlertWindow("Oferta została utworzona").Show();
                _navigationService.GoBack();

            }
        }
    }

   
}
