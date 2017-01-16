using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Pokoj: IComparable<Pokoj>
    {
        private int nrPokoju;
        private double cenaZaDzien;

        public int _nrPokoju { get { return nrPokoju; } }
        public double _cenaZaDzien { get { return cenaZaDzien; } }

        public Pokoj(int nrPokoju, double cenaZaDzien)
        {
            this.nrPokoju = nrPokoju;
            this.cenaZaDzien = cenaZaDzien;
        }

        public override string ToString()
        {
            string wyjscie = "Pokój, nr: " + nrPokoju + ", cena za dzień: " + cenaZaDzien;
            return wyjscie;
        }
        
        public int CompareTo(Pokoj other)
        {
            return this.nrPokoju.CompareTo(other.nrPokoju);
        }
    }
}
