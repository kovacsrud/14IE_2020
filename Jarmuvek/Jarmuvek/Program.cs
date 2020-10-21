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
                Console.WriteLine($"{i},{i.GyorshajtottE(50)}");
                if (i.GetType()==typeof(Robogo))
                {
                    Robogo robogo = (Robogo)i;
                    Console.WriteLine(robogo.HaladhatItt(40));
                }
                if (i.GetType() == typeof(AudiS8))
                {
                    Console.WriteLine("Ez Audi");
                }
            }

            Console.ReadKey();
        }
    }
}
