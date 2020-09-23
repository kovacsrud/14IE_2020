using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatOOP
{
    class Program
    {
        static void Main(string[] args)
        {

            Allat allat = new Allat("Ubul",16);
            Allat masikAllat = new Allat("Zénó",8);

            Allat allat2 = new Allat();

            allat.Eszik();
            allat.Mozog();
            allat.Alszik();
            Console.WriteLine(allat.GetNev());

            masikAllat.Mozog();
            Console.WriteLine(masikAllat.GetNev());

            Console.ReadKey();
        }
    }
}
