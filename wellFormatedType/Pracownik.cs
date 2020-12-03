using System;
using System.Collections.Generic;
using System.Text;

namespace wellFormatedType
{
    class Pracownik
    {
        private string _nazwisko;
        private DateTime _dataZatrudnienia;
        private decimal _wynagrodzenie;
        public string Nazwisko {
            get => _nazwisko; 
            set 
            {
                value = value.TrimEnd();
                value = value.TrimStart();
                _nazwisko = value;
            }
        }
        public DateTime DataZatrudnienia {
            get => _dataZatrudnienia;
            set
            {
                if (value > DateTime.Today)
                    throw new ArgumentException();
                else
                    _dataZatrudnienia = value;
            } 
        }
        public decimal Wynagrodzenie {
            get => _wynagrodzenie;
            set 
            {
                if (value < 0)
                    _wynagrodzenie = 0;
                else
                    _wynagrodzenie = value;
            } 
        }
        public int CzasZatrudnienia => (DateTime.Now - DataZatrudnienia).Days / 30;

        public Pracownik(string nazwisko, DateTime dataZatrudnienia, decimal wynagrodzenie)
        {
            Nazwisko = nazwisko;
            DataZatrudnienia = dataZatrudnienia;
            Wynagrodzenie = wynagrodzenie;
        }

        public Pracownik()
        {
            Nazwisko = "Anonim";
            DataZatrudnienia = DateTime.Today;
            Wynagrodzenie = 0;
        }

        public override string ToString() => $"({Nazwisko}, {DataZatrudnienia:d MMM yyyy} ({CzasZatrudnienia}), {Wynagrodzenie} PLN)";
    }
}
