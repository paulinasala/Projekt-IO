using InteligentnyPosrednikNieruchomosci.Views;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Windows;

namespace InteligentnyPosrednikNieruchomosci
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (DbConnection connection = MySqlClientFactory.Instance.CreateConnection())
            {
                var str = "Data Source=posrednik.czgecepfvj6q.eu-central-1.rds.amazonaws.com;Initial Catalog=posrednik_nieruchomosci;User ID=admin; Password=projektio20;";

                connection.ConnectionString = str;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "Select * FROM oferta";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var a = dataReader["id_klienta"];
                        var dzielnica = dataReader["dzielnica"];
                    }
                }
            }

            var navigationService = MainFrame.NavigationService;
            navigationService.Navigate(new StartView(navigationService));
        }

    }
}
