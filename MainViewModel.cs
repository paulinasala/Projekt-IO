using InteligentnyPosrednikNieruchomosci.Views;
using System.Runtime.Remoting.Channels;
using System.Windows.Input;
using System.Windows.Navigation;

namespace InteligentnyPosrednikNieruchomosci
{
    internal class MainViewModel : BaseViewModel
    {

       
        private readonly NavigationService _navigationService;
        public ICommand Zaloguj { get; set; }
        public ICommand Zarejestruj { get; set; }
       



        public MainViewModel(NavigationService ns)
        {
            _navigationService = ns;
            Zarejestruj = new RelayCommand(ZarejestrujMethod);
        }

        private void ZarejestrujMethod()
        {
            _navigationService.Navigate(new RegistrationView(_navigationService));
        }

        void ZalogujMethod()
        {

        }
       
    }
}