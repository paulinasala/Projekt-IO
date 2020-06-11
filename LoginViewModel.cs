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
    internal class LoginViewModel
    {
        private NavigationService _navigationService;
        public ICommand Logowanie { get; set; }
        public ICommand Cofnij { get; set; }

        public string LoginText { get; set; }
        private System.Windows.Controls.PasswordBox Pass { get; set; }
        private string PasswordText => Pass.Password;

        public LoginViewModel(NavigationService navigationService, System.Windows.Controls.PasswordBox passwordInput)
        {
            _navigationService = navigationService;
            Logowanie = new RelayCommand(LogowanieMethod);
            Cofnij = new RelayCommand(CofnijMethod);
            Pass = passwordInput;

        }

        private void LogowanieMethod()
        {
            if (string.IsNullOrEmpty(LoginText) || string.IsNullOrEmpty(PasswordText))
            {
                new AlertWindow("Wypełnij wszystkie pola!").Show();
                return;
            }
            if (PasswordText.Length < 6)
            {
                new AlertWindow("Hasło musi mieć min. 6 znaków!").Show();
                return;
            }
            using (DbConnection connection = MySqlClientFactory.Instance.CreateConnection())
            {
                var str = "Data Source=posrednik.czgecepfvj6q.eu-central-1.rds.amazonaws.com;Initial Catalog=posrednik_nieruchomosci;User ID=admin; Password=projektio20;";

                connection.ConnectionString = str;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT id_klienta,login,haslo from klient where login like '{LoginText}'";

                bool result = false;
                int id = 0;
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        result = dataReader["login"].ToString() == LoginText && dataReader["login"].ToString()==LoginText&& dataReader["haslo"].ToString() == PasswordText;
                        id = (int)dataReader["id_klienta"];

                    }
                }
                if (!result)
                {
                    new AlertWindow("Niepoprawny login luib hasło").Show();
                    return;
                }

                _navigationService.Navigate(new PanelView(_navigationService,new Klient(id, LoginText)));

            }
        }


        private void CofnijMethod()
        {
            _navigationService.GoBack();
        }

    }
}


