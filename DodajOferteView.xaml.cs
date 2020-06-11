using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InteligentnyPosrednikNieruchomosci
{
    /// <summary>
    /// Logika interakcji dla klasy DodajOferteView.xaml
    /// </summary>
    public partial class DodajOferteView : Page
    {
        public DodajOferteView(NavigationService navigationService,Klient k)
        {
            InitializeComponent();
            DataContext = new DodajOferteViewModel(navigationService, k);
        }
    }
}
