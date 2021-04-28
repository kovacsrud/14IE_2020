using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FuvarAdat> fuvarok = new List<FuvarAdat>();
            try
            {
                var sorok = File.ReadAllLines("fuvar.csv",Encoding.Default);
                for (int i = 1; i < sorok.Length; i++)
                {
                    fuvarok.Add(new FuvarAdat(sorok[i]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Adatok:{fuvarok.Count}");

            var taxis = fuvarok.FindAll(x=>x.Id==6185);

            Console.WriteLine($"Összbevétel:{taxis.Sum(x=>x.Viteldij)},Fuvarok száma:{taxis.Count}");

            var fizmodok = fuvarok.ToLookup(x=>x.FizetesiMod);

            foreach (var i in fizmodok)
            {
                Console.WriteLine($"{i.Key}-{i.Count()} fuvar,{i.Sum(x=>x.Viteldij)}");
            }

            var leghosszabb = fuvarok.Find(x=>x.Idotartam==fuvarok.Max(y=>y.Idotartam));
            Console.WriteLine($@"Leghosszabb fuvar
                Fuvar hossza:{leghosszabb.Idotartam}
                Taxi azonosító:{leghosszabb.Id}
                Megtett táv:{leghosszabb.MegtettTav}
            ");

            var hibas = fuvarok.FindAll(x=>x.Idotartam>0 && x.Viteldij>0 && x.MegtettTav==0);

            

            try
            {
                FileStream fajl = new FileStream("hibas.txt",FileMode.Create);
                StreamWriter sw = new StreamWriter(fajl,Encoding.Default);

                foreach (var i in hibas)
                {
                    sw.WriteLine($"{i.Id};{i.Indulas};{i.Idotartam};{i.MegtettTav};{i.Viteldij};{i.Borravalo};{i.FizetesiMod}");
                }
                sw.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
