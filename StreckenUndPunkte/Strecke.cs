using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreckenUndPunkte
{
    class Strecke
    {
        public readonly Punkt P1;
        public readonly Punkt P2;

        public Strecke(Punkt p1, Punkt p2)
        {
            P1 = p1;
            P2 = p2;
        }

        public double Length() => Math.Sqrt(Math.Pow((P2.X - P1.X), 2) + Math.Pow((P2.Y - P1.Y), 2));

        public override string ToString()
        {
            return $"Strecke [p1={P1}, p2={P2}], Länge: {Length():F}";
        }

        public override bool Equals(object obj)
        {
            return obj is Strecke strecke && strecke.P1.Equals(P1) && strecke.P2.Equals(P2);
        }
    }
}
