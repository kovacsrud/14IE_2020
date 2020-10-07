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

            //foreach (var i in ev2007)
            //{
            //    Console.WriteLine($"{i.Ev}.{i.Honap}.{i.Nap}");
            //}

            //Mennyi volt az év átlaghőmérséklete?
            var atlagho2007 = ev2007.Average(x=>x.Homerseklet);
            Console.WriteLine(atlagho2007);

            Console.WriteLine(ev2007.FindAll(x=>x.Honap==3).Average(x=>x.Homerseklet));

            //Melyik napon volt a legmelegebb 2007_ben?

            var legmelegebb = ev2007.Find(x=>x.Homerseklet==ev2007.Max(y=>y.Homerseklet));

            Console.WriteLine($"{legmelegebb.Honap}.{legmelegebb.Nap}-{legmelegebb.Ora},{legmelegebb.Homerseklet}");

            Console.ReadKey();
        }
    }
}
