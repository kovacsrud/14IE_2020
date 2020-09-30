using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emberek_ABS
{
    class Program
    {
        static void Main(string[] args)
        {
            Sportolo sportember = new Sportolo
            {
                Sportag="kajak",
                Magassag=185,
                Nev="Egon",
                Suly=80,
                SzuletesiEv=1999
            };

            sportember.Mozog();
            sportember.Sport();
            Console.WriteLine(sportember.GetEletkor());

            Nyugdijas ny = new Nyugdijas {
            Magassag=178,
            Munkaviszony=45,
            Nev="Erhard",
            Suly=112,
            SzuletesiEv=1946
            };

            Console.WriteLine(ny.GetEletkor());
            ny.Alszik();

    

            Console.ReadKey();
        }
    }
}
