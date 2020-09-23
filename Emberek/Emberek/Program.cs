using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emberek
{
    class Program
    {
        static void Main(string[] args)
        {
            Ember ember = new Ember("Zöld", "Géza", 170, "Elek", 1989);

            Console.WriteLine($"{ember.Vezeteknev},{ember.Keresztnev}");

            Console.ReadKey();
        }
    }
}
