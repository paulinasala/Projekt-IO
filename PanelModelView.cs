using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace InteligentnyPosrednikNieruchomosci
{
    internal class PanelViewModel
    {

        private NavigationService _navigationService;
        public ICommand Wyszukaj{ get; set; }
        public ICommand Cofnij { get; set; }
        public ICommand DodajOferte { get; set; }
        public ICommand UsunOferte { get; set; }
        public ICommand UsunKonto { get; set; }
        public ICommand Wyswietl { get; set; }
        public Klient Zalogowany { get; set; }
        public PanelViewModel(NavigationService navigationService, Klient klient)
        {
            _navigationService = navigationService;
            Wyszukaj = new RelayCommand(WyszukajMethod);
            Cofnij = new RelayCommand(CofnijMethod);
            DodajOferte = new RelayCommand(DodajOfeteMethod);
            //UsunOferte= new RelayCommand(UsunOferteMethod);
            UsunKonto = new RelayCommand(UsunKontoMethod);
            Wyswietl = new RelayCommand(WyswietlMethod);
            Zalogowany = klient;



        }

        private void WyswietlMethod()
        {
            using (DbConnection connection = MySqlClientFactory.Instance.CreateConnection())
            {
                var str = "Data Source=posrednik.czgecepfvj6q.eu-central-1.rds.amazonaws.com;Initial Catalog=posrednik_nieruchomosci;User ID=admin; Password=projektio20;";

                connection.ConnectionString = str;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * from oferta where id_klienta like '{Zalogowany.IdKlienta}'";

                List<Oferta> oferty = new List<Oferta>();
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        oferty.Add(new Oferta((int)dataReader["liczba_pomieszczen"], (string)dataReader["dzielnica"], (float)dataReader["cena"], (float)dataReader["metraz"])); 

                    }
                }
                if (oferty.Count==0)
                {
                    new AlertWindow("Nie masz żadnych ofert").Show();
                    return;
                }
              

                _navigationService.Navigate(new MyOffers(_navigationService,oferty));

            }

        }

        private void UsunKontoMethod()
        {
            MessageBoxResult r = MessageBox.Show("Czy chcesz usunac?", "Usun konto", MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                using (DbConnection connection = MySqlClientFactory.Instance.CreateConnection())
                {
                    var str = "Data Source=posrednik.czgecepfvj6q.eu-central-1.rds.amazonaws.com;Initial Catalog=posrednik_nieruchomosci;User ID=admin; Password=projektio20;";

                    connection.ConnectionString = str;
                    connection.Open();
                    DbCommand command = connection.CreateCommand();
                    command.CommandText = $"DELETE FROM klient WHERE id_klienta like '{Zalogowany.IdKlienta}'";
                    command.ExecuteNonQuery();

                }
                
                _navigationService.GoBack();
            }
        }

      

        private void DodajOfeteMethod()
        {
            
            _navigationService.Navigate(new DodajOferteView(_navigationService, Zalogowany));

        }

        private void WyszukajMethod()
        {
            new AlertWindow("Nie zaimplementowano metody.").Show();

        }

        private void CofnijMethod()
        {
            _navigationService.GoBack();
        }

    }
}