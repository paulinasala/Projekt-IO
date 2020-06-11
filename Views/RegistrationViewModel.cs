using MySql.Data.MySqlClient;
using System.Collections.Specialized;
using System.IO.Packaging;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Data.Common;
using System.Windows;
using System;
using System.Windows.Forms;

namespace InteligentnyPosrednikNieruchomosci.Views
{
    internal class RegistrationViewModel
    {

        private NavigationService _navigationService;
        public ICommand Rejestracja { get; set; }
        public ICommand Cofnij { get; set; }
        public string OfertaView { get; set; }
        public string LoginText{ get; set; }
        public string PasswordText { get; set; }
        public string EmailText { get; set; }
        public string NameText { get; set; }
        public string SurnameText { get; set; }
        public string PhoneText { get; set; }

        public RegistrationViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            Rejestracja = new RelayCommand(RejestracjaMethod);
            Cofnij = new RelayCommand(CofnijMethod);
         
        }

        private void RejestracjaMethod()
        {
            if (string.IsNullOrEmpty(LoginText)  || string.IsNullOrEmpty(EmailText) || string.IsNullOrEmpty(NameText) || string.IsNullOrEmpty(SurnameText) || string.IsNullOrEmpty(PhoneText))
            {
                new AlertWindow("Wypełnij wszystkie pola!").Show();
                return;
            }
            using (DbConnection connection = MySqlClientFactory.Instance.CreateConnection())
            {
                var str = "Data Source=posrednik.czgecepfvj6q.eu-central-1.rds.amazonaws.com;Initial Catalog=posrednik_nieruchomosci;User ID=admin; Password=projektio20;";

                connection.ConnectionString = str;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT login from klient where login like '{LoginText}'";

                string login = string.Empty;
                using (DbDataReader dataReader = command.ExecuteReader())
                {                  
                    while (dataReader.Read())
                    {
                        login = dataReader["login"].ToString();
                       

                    }
                }
                if (LoginText == login)
                {
                    new AlertWindow("Login jest już zajęty").Show();
                    return;
                }
                command.CommandText = $"INSERT INTO klient VALUES(null,\"{LoginText}\",\"haslo\",\"{NameText}\",\"{EmailText}\",\"{SurnameText}\",\"{PhoneText}\")";
                command.ExecuteNonQuery();

            }
        }


        private void CofnijMethod()
        {
            //MySqlConnection connection = new MySqlConnection(connectionString)
            _navigationService.GoBack();
        }

    }
}