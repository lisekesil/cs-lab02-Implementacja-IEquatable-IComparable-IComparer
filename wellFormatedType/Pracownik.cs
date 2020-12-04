using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace wellFormatedType
{
    class Pracownik : IEquatable<Pracownik>, IComparable<Pracownik>
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

        public bool Equals( Pracownik other)
        {
            if(other == null)
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other)) return true;

            return (other.Nazwisko == Nazwisko && other.Wynagrodzenie == Wynagrodzenie && other.DataZatrudnienia == DataZatrudnienia);

        }

        public override bool Equals(object obj)
        {
            if (obj is Pracownik)
            {
                return Equals((Pracownik)obj);
            }
            else
                return false;
        }

        public override int GetHashCode() => (Nazwisko, DataZatrudnienia, Wynagrodzenie).GetHashCode();
        
        public static bool Equals(Pracownik p1, Pracownik p2)
        {
            if ((p1 is null) && (p2 is null)) return true;
            if (p1 is null) return false;

            return p1.Equals(p2);
        }

        public static bool operator ==(Pracownik p1, Pracownik p2) => Equals(p1, p2);
        public static bool operator !=(Pracownik p1, Pracownik p2) => !(p1 == p2);
        public int CompareTo(Pracownik other)
        {
            if (other == null) return 1;

            /*
             if (other is null) return 1; // w C#: null jest najmniejszą wartością (`this > null`)
             if (this.Equals(other)) return 0; //zgodność z Equals (`this == other`)

             if (this.Nazwisko != other.Nazwisko)
                return this.Nazwisko.CompareTo(other.Nazwisko);
    
                // ponieważ nazwiska równe, porządkujemy wg daty
             if (!this.DataZatrudnienia.Equals(other.DataZatrudnienia)) // != zamiast !Equals
                  return this.DataZatrudnienia.CompareTo(other.DataZatrudnienia);

             // ponieważ nazwiska równe i daty równe, porządkujemy wg wynagrodzenia
             return this.Wynagrodzenie.CompareTo(other.Wynagrodzenie);
             */

            if (Nazwisko.CompareTo(other.Nazwisko) > 0) {
                return 1;
            } else if(Nazwisko.CompareTo(other.Nazwisko) == 0)
            {
                if(DataZatrudnienia.CompareTo(other.DataZatrudnienia) > 0)
                {
                    return 1;
                } else if(DataZatrudnienia.CompareTo(other.DataZatrudnienia) == 0)
                {
                    if(Wynagrodzenie.CompareTo(other.Wynagrodzenie) > 0)
                    {
                        return 1;
                    } else if(Wynagrodzenie.CompareTo(other.Wynagrodzenie) == 0)
                    {
                        return 0;
                    }
                    return -1;
                }
                return -1;
            }
            return -1;

        }

    }
}
