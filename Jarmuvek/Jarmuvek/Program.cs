using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarmuvek
{
    class Program
    {
        static void Main(string[] args)
        {
            Orszagut orszagut = new Orszagut("jarmuadatok.txt");

            foreach (var i in orszagut.Jarmuvek)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
