using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteligentnyPosrednikNieruchomosci
{
    class MainWindowViewModel
    {
        public ICommand Zaloguj { get; set; }
        public ICommand Zarejestruj { get; set; }

        public MainWindowViewModel()
        {
            Zaloguj = new RelayCommand(ZalogujMethod);
            Zarejestruj = new RelayCommand(ZarejestrujMethod);
        }

        private void ZarejestrujMethod()
        {
            var a = new MainWindow();
            a.Show();
        }

        void ZalogujMethod()
        {

        }
        
    }
}
