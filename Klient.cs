using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteligentnyPosrednikNieruchomosci
{
   public class Klient
    {
        public int IdKlienta { get; private set; }
        public string Name { get; private set; }



        public Klient(int id, string n )
        {
            IdKlienta = id;
            Name = n;
        }
    }
}
