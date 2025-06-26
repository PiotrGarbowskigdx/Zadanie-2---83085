
using System;

namespace ProstyWektor
{
    // Bardzo prosta klasa wektora 3D (lub dowolnego rozmiaru)
    public class Wektor
    {
        // Tablica przechowująca współrzędne
        public double[] Wartosci;

        // Konstruktor tworzący pusty wektor (wszystkie wartości = 0)
        public Wektor(int rozmiar)
        {
            Wartosci = new double[rozmiar];
        }

        // Konstruktor tworzący wektor z gotowej tablicy
        public Wektor(double[] wartosciStartowe)
        {
            // Tworzymy kopię, aby nie zmieniać tablicy przekazanej z zewnątrz
            Wartosci = new double[wartosciStartowe.Length];
            for (int i = 0; i < wartosciStartowe.Length; i++)
                Wartosci[i] = wartosciStartowe[i];
        }

        // Dodawanie dwóch wektorów (statyczne, bo zwraca nowy wektor)
        public static Wektor Dodaj(Wektor a, Wektor b)
        {
            if (a.Wartosci.Length != b.Wartosci.Length)
                return null; // inny rozmiar -> brak wyniku

            Wektor wynik = new Wektor(a.Wartosci.Length);
            for (int i = 0; i < a.Wartosci.Length; i++)
                wynik.Wartosci[i] = a.Wartosci[i] + b.Wartosci[i];
            return wynik;
        }

        // Iloczyn skalarny (mnożymy i sumujemy po kolei)
        public static double IloczynSkalarny(Wektor a, Wektor b)
        {
            if (a.Wartosci.Length != b.Wartosci.Length)
                return double.NaN; // inny rozmiar -> brak wyniku

            double suma = 0;
            for (int i = 0; i < a.Wartosci.Length; i++)
                suma += a.Wartosci[i] * b.Wartosci[i];
            return suma;
        }

        // Długość (norma) wektora
        public double Dlugosc()
        {
            return Math.Sqrt(IloczynSkalarny(this, this));
        }

        // Ładne wypisanie
        public override string ToString()
        {
            return "[" + string.Join(", ", Wartosci) + "]";
        }
    }

    class Program
    {
        static void Main()
        {
            // Tworzymy 2 wektory 3‑wymiarowe
            Wektor a = new Wektor(new double[] { 1, 2, 3 });
            Wektor b = new Wektor(new double[] { 4, 5, 6 });

            // Dodawanie
            Wektor suma = Wektor.Dodaj(a, b);

            // Iloczyn skalarny
            double iloczyn = Wektor.IloczynSkalarny(a, b);

            // Długość
            double dlugoscA = a.Dlugosc();

            // Pokazujemy wyniki
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("a + b = " + suma);
            Console.WriteLine("Iloczyn skalarny a·b = " + iloczyn);
            Console.WriteLine("Długość |a| = " + dlugoscA);
        }
    }
}
