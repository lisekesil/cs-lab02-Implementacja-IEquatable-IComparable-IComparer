using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace wellFormatedType
{
    class WgCzasuZatrudnieniaPotemWynagrodzeniaComparer : IComparer<Pracownik>
    {
        public int Compare( Pracownik x, Pracownik y)
        {
            if (x is null && y is null) return 0;
            if (x is null && !(y is null)) return -1;
            if (!(x is null) && y is null) return 1;

            if (x.CzasZatrudnienia != y.CzasZatrudnienia)
                return (x.CzasZatrudnienia.CompareTo(y.CzasZatrudnienia));

            return x.Wynagrodzenie.CompareTo(y.Wynagrodzenie);

        }
    }
}
