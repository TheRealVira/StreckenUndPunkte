using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreckenUndPunkte
{
    internal struct Punkt
    {
        public Punkt(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        public double Länge => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        
        public override string ToString()
        {
            return $"Punkt [x={X}, y={Y}]";
        }

        public override bool Equals(object obj)
        {
            return obj is Punkt punkt && punkt.X.Equals(X) && punkt.Y.Equals(Y);
        }
    }
}
