using System;
using System.Collections.Generic;
using System.Linq;

namespace StreckenUndPunkte
{
    class Program
    {
        private static Random _rand;
        private const int STRECKEN = 10;

        private const bool RANDOM = false;

        public static Strecke[] VordefinierteStreckes= {
            new Strecke(new Punkt(3, 5), new Punkt(7, 6)),
            new Strecke(new Punkt(3, 6), new Punkt(8, 7)),
            new Strecke(new Punkt(4, 7), new Punkt(9, 7)),
            new Strecke(new Punkt(10, 11), new Punkt(12, 13))
        };

        static void Main(string[] args)
        {
            _rand = new Random(DateTime.Now.Millisecond);

            var strecken = RANDOM?GenStrecken(STRECKEN): VordefinierteStreckes;
            var num = 0;

            var numberedStrecken = strecken.ToDictionary(strecke => num++);
            var listofPoints = strecken.Select(x => x.P1).ToList();
            listofPoints.AddRange(strecken.Select(x => x.P2));

            foreach (var strecke in numberedStrecken)
            {
                Console.WriteLine($"{strecke.Key}:\t{strecke.Value}");
                var listOfStrecken1 = new List<Strecke>();
                var listOfStrecken2 = new List<Strecke>();

                foreach (var listofPoint in listofPoints)
                {
                    if(!listofPoint.Equals(strecke.Value.P1))
                    {
                        listOfStrecken1.Add(new Strecke(strecke.Value.P1, listofPoint));
                        continue;
                    }

                    if (!listofPoint.Equals(strecke.Value.P2))
                    {
                        listOfStrecken2.Add(new Strecke(strecke.Value.P2, listofPoint));
                    }
                }

                var furthest1 = listOfStrecken1.Max(x => x.Length());
                var furthest2 = listOfStrecken2.Max(x => x.Length());

                Console.WriteLine($"\tDistance is furthest to:");
                Console.WriteLine($"\tp1\t{furthest1}");
                Console.WriteLine($"\tp2\t{furthest2}");
            }


            Console.ReadKey(true);
        }

        private static Strecke[] GenStrecken(int count)
        {
            var toRet = new Strecke[count];
            for (var i = 0; i < count; i++)
            {
                toRet[i]= new Strecke(GenPunkt(), GenPunkt());
            }

            return toRet;
        }

        private static Punkt GenPunkt()
        {
            return new Punkt(_rand.Next(int.MinValue, int.MaxValue), _rand.Next(int.MinValue, int.MaxValue));
        }
    }
}
