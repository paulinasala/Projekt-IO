using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteligentnyPosrednikNieruchomosci
{
    class AlertWindowViewModel
    {
    

        public AlertWindowViewModel(string text, Action p)
        {
           AlertText = text;
            AlertButton = new RelayCommand(p);
        }

        public string AlertText { get; set; }
        public ICommand AlertButton { get; set; }

    }
}
