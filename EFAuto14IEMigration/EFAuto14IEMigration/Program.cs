using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAuto14IEMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            var autonyilvantartas = new AutoContext();
            
            //adatok felvitele

            autonyilvantartas.SaveChanges();

            Console.ReadKey();
        }
    }
}
