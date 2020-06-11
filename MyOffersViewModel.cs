using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace InteligentnyPosrednikNieruchomosci
{
    internal class MyOffersViewModel
    {
        private NavigationService _navigationService;
        public ICommand Cofnij { get; set; }
        public ICommand UsunOferte { get; set; }
        public List<Oferta> ListaOfert { get; set; }
        public MyOffersViewModel(System.Windows.Navigation.NavigationService navigationService, List<Oferta> oferty)
        {
            _navigationService = navigationService;
            ListaOfert = oferty;
            Cofnij = new RelayCommand(CofnijMethod);
            UsunOferte = new RelayCommand(UsunMethod);
            foreach (var o in ListaOfert) o.UsunOferte = UsunOferte;

        }
        private void CofnijMethod()
        {
            _navigationService.GoBack();
        }
        private void UsunMethod()
        {
            new AlertWindow("Nie zaimplementowano metody.").Show();
        }
    }
}