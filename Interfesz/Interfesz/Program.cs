using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfesz
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISikidom> sikidomok = new List<ISikidom>();

            Kor k1 = new Kor(11.6);
            Kor k2 = new Kor(16);
            Kor k3 = new Kor(32.12);

            Teglalap t1 = new Teglalap(12, 31.5);
            Teglalap t2 = new Teglalap(33, 68);
            Teglalap t3 = new Teglalap(29, 46.51);

            sikidomok.Add(k1);
            sikidomok.Add(k2);
            sikidomok.Add(k3);
            sikidomok.Add(t1);
            sikidomok.Add(t2);
            sikidomok.Add(t3);

            Console.WriteLine($"Kerületek:{sikidomok.Sum(x => x.Kerulet())}");
            Console.WriteLine($"Területek:{sikidomok.Sum(x => x.Terulet())}");

            //Hogyan lehet különbséget tenni közöttük?
            foreach (var i in sikidomok)
            {
                if (i.GetType()==typeof(Kor))
                {
                    var elem = (Kor)i;
                    Console.WriteLine($"Sugara:{elem.Sugar}");
                }
                if (i.GetType() == typeof(Teglalap))
                {
                    var elem = (Teglalap)i;
                    Console.WriteLine($"A:{elem.A},B:{elem.B}");
                }
            }

            var korterulet = sikidomok.Where(x => x.GetType() == typeof(Kor)).Sum(x => x.Terulet());
            Console.WriteLine(korterulet);

            Console.ReadKey();
        }
    }
}
