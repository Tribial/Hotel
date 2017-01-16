using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Osoba
    {
        private string imie;
        private string nazwisko;

        public Osoba(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public override string ToString()
        {
            string wyjscie = "Gość, " + imie + " " + nazwisko;
            return wyjscie;
        }
    }
}
