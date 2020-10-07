using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idojaras
{
    class Program
    {
        static void Main(string[] args)
        {
            //A főprogramban a fájlkezelés most tilos.
            IdojarasAdatok adatok = new IdojarasAdatok("idojaras.csv", true, ';');

            Console.WriteLine(adatok.IdojarasAdatLista.Count);

            Console.WriteLine(adatok.IdojarasAdatLista.Max(x=>x.Ev));
            Console.WriteLine(adatok.IdojarasAdatLista.Min(x => x.Ev));

            var ev2007 = adatok.IdojarasAdatLista.FindAll(x => x.Ev == 2007);


            Console.ReadKey();
        }
    }
}
