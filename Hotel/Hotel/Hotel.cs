using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Hotel : IHotel, IData
    {
        private SortedList<Pokoj, Osoba> rezerwacje = new SortedList<Pokoj,Osoba>();
        public SortedList<Pokoj, Osoba> _rezerwacje { get { return rezerwacje; } }
        private double zysk = -50;
        public DateTime data;

        public void DodajRezerwacje(string imie, string nazwisko, int nr, double cena)
        {
            Osoba os = new Osoba(imie, nazwisko);
            Pokoj pk = new Pokoj(nr, cena);
            zysk += cena;
            rezerwacje.Add(pk, os);
        }
        public void OdwolajRezerwacje()
        {
            rezerwacje.RemoveAt(rezerwacje.Count - 1);
        }

        public void UstawDate(DateTime data)
        {
            this.data = data;
        }
        public bool SprawdzDate(DateTime data)
        {
            return data > DateTime.Now;
        }

        public override string ToString()
        {
            string wyjscie = "Rezerwacje:\n\nData: " + data.ToShortDateString();
            foreach(var a in rezerwacje)
            {
                wyjscie += "\n\n";
                string pokoj = a.Key.ToString()+ "; " + a.Value.ToString();
                wyjscie += "[" + pokoj + "]";
            }
            wyjscie += "\n\nZysk: " + zysk;
            return wyjscie;
        }
    }
}
