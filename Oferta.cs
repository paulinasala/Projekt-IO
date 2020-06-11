using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteligentnyPosrednikNieruchomosci
{
    public class Oferta
    {
        public string Dzielnica { get; private set; }
        public float Cena { get; private set; }

        public float Metraz { get; private set; }
        public int  LiczbaPomieszczen { get; private set; }
        public System.Windows.Input.ICommand UsunOferte { get; set; }



        public Oferta(int l, string d, float c, float m)
        {
            Dzielnica = d;
            Cena = c;
            Metraz = m;
            LiczbaPomieszczen = l;
        }
    }
}
