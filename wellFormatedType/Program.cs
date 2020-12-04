using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace wellFormatedType
{
    class Program 
    {
        static void Main(string[] args)
        {
            var p1 = new Pracownik("Molenda", new DateTime(2011, 8,9), 400);
            var p2 = new Pracownik("Abacki", new DateTime(2011, 8, 9), 200);
            var p3 = new Pracownik("Abacki", new DateTime(2016, 5, 3), 300);
            var p33 = new Pracownik("Abacki", new DateTime(2016, 5, 3), 400);
            var p34 = new Pracownik("Abacki", new DateTime(2016, 5, 3), 100);
            var p4 = new Pracownik("Nowak", new DateTime(2017, 4, 6), 500);
            var p5 = new Pracownik("Kowalski", new DateTime(2015, 12, 3), 500);

            List<Pracownik> pracownicy = new List<Pracownik> { p1, p2, p3, p4, p5, p33,p34 };
            pracownicy.Sort();
            foreach(var item in pracownicy)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            pracownicy.Sort(new WgCzasuZatrudnieniaPotemWynagrodzeniaComparer());
            foreach(var item in pracownicy)
            {
                Console.WriteLine(item);
            }

            pracownicy.Sort((p1, p2) => (p1.Wynagrodzenie != p2.Wynagrodzenie) ?
                            (-1) * (p1.Wynagrodzenie.CompareTo(p2.Wynagrodzenie)) :
                            p1.CzasZatrudnienia.CompareTo(p2.CzasZatrudnienia)
            );
            foreach (var pracownik in pracownicy)
                System.Console.WriteLine(pracownik);
        }

 
    }
}
