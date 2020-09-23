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

            Allat allat = new Allat();
            Allat masikAllat = new Allat();

            allat.SetNev("Ubul");


            allat.Eszik();
            allat.Mozog();
            allat.Alszik();
            Console.WriteLine(allat.GetNev());

            masikAllat.Mozog();


            Console.ReadKey();
        }
    }
}
