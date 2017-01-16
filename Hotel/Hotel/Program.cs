using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Program
    {
        private static Hotel ht = new Hotel();
        private static bool zlaData;
        static void Main()
        {
            string wybor;
            ZmienDate();
            while(true)
            {
                Console.WriteLine("Co chcesz zrobić?");
                Console.WriteLine("1. Zmień datę.");
                Console.WriteLine("2. Dodaj rezerwację.");
                Console.WriteLine("3. Usuń rezerwację.");
                Console.WriteLine("4. Pokaż wszystkie rezerwacje.");
                Console.WriteLine("5. Wyjdź z programu.");
                Console.WriteLine("--------------------------------\n");

                wybor = Console.ReadLine();
                if (wybor == "1")
                    ZmienDate();
                else if (wybor == "2")
                    DodajRezerwacje();
                else if (wybor == "3")
                    UsunRezerwacje();
                else if (wybor == "4")
                    PokazRezerwacje();
                else if (wybor == "5")
                    return;
                else
                {
                    Console.WriteLine("Wybierz z podanych możliwości.");
                    Continue();
                }
            }
        }
        private static void PokazRezerwacje()
        {
            Console.WriteLine(ht.ToString());
            Continue();
        }
        private static void UsunRezerwacje()
        {
            if(ht._rezerwacje.Count != 0)
            {
                ht.OdwolajRezerwacje();
                Console.WriteLine("Odwołano rezerwację.");
            }
            else
            {
                Console.WriteLine("W systemie nie ma żadnych rezerwacji.");
            }
            Continue();
        }
        private static void DodajRezerwacje()
        {
            int nrPokoju;
            double cenaZaDobe;
            string[] imieNazwisko;
            Console.WriteLine("Proszę podać numer pokoju: ");
            try { nrPokoju = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception)
            {
                Console.WriteLine("Numer pokoju powinien być liczbą całkowitą.");
                Continue();
                return;
            }
            foreach(var pok in ht._rezerwacje)
            {
                if (nrPokoju == pok.Key._nrPokoju)
                {
                    Console.WriteLine("Niestety ten pokój jest już zarezerwowany.");
                    Continue();
                    return;
                }
            }
            Console.WriteLine("Proszę podać cenę za dobę: ");
            try { cenaZaDobe = Convert.ToDouble(Console.ReadLine()); }
            catch (Exception)
            {
                Console.WriteLine("Cena powinna być liczbą zmiennoprzecinkową.");
                Continue();
                return;
            }
            Console.WriteLine("Proszę podać imię oraz nazwisko, oddzielone spacją.");
            string nazwa = Console.ReadLine();
            if (nazwa.Contains(' '))
            {
                imieNazwisko = nazwa.Split(' ');
                if(imieNazwisko.Length != 2)
                {
                    Console.WriteLine("Coś poszło nie tak!");
                    Continue();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Imie i nazwisko powinny zostać podane po spacji.");
                Continue();
                return;
            }
            ht.DodajRezerwacje(imieNazwisko[0], imieNazwisko[1], nrPokoju, cenaZaDobe);
            Console.WriteLine("Rezerwacja dodana pomyślnie.");
            Continue();
        }
        private static void ZmienDate()
        {
            zlaData = true;
            while (zlaData)
            {
                Console.WriteLine("Ustaw datę rezerwacji. Format: rrrr-mm-dd.\nData powinna być większa od aktualnej daty.");
                string data = Console.ReadLine();
                UstawISprawdz(data);
                Continue();
            }
        }
        private static void Wybor()
        {
            Console.WriteLine();
        }
        private static void UstawISprawdz(string data)
        {
            string[] pom = data.Split('-');
            if(pom.Length != 3)
            {
                Console.WriteLine("Niestety, ale data jest błędna.");
                
            }
            else
            {
                try
                {
                    int rok = Convert.ToInt32(pom[0]);
                    int miesiac = Convert.ToInt32(pom[1]);
                    int dzien = Convert.ToInt32(pom[2]);
                    DateTime dt = new DateTime(rok, miesiac, dzien);
                    if (ht.SprawdzDate(dt) && miesiac <= 12 && miesiac >= 0 && dzien >= 0 && dzien <= 31 && rok - DateTime.Now.Year <= 5)
                    {
                        Console.WriteLine("Data się zgadza.");
                        zlaData = false;
                        ht.UstawDate(dt);
                    }
                    else
                    {
                        Console.WriteLine("Niestety, ale data jest błędna.");
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Niestety, ale data jest błędna.");
                }
            }
        }

        private static void Continue()
        {
            Console.WriteLine("Wciśnij dowolny klawisz aby kontynuować...\n");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
