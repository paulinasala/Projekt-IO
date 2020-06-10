using InteligentnyPosrednikNieruchomosci.Views;
using System.Windows;
using System.Data.Common;
using System.Configuration;
using MySql.Data.MySqlClient;
using System;

namespace InteligentnyPosrednikNieruchomosci
{

    public partial class MainWindow : Window
    {
        public MySqlConnection Connection { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                    return;
                }

                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                    return;
                }





                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    // Advance to the next results
                    while (dataReader.Read())
                    {
                        // Output results using row names
                        Console.WriteLine($"{dataReader["ProdId"]} " +
                            $"{dataReader["Product"]}");
                    }
                }

            }


            var navigationService = MainFrame.NavigationService;
            navigationService.Navigate(new StartView(navigationService));
        }

    }
}
