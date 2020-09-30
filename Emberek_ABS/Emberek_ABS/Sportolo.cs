using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emberek_ABS
{
    public class Sportolo : Ember
    {
        public string Sportag { get; set; }

        public override void Alszik()
        {
            Console.WriteLine("A sportoló sokat alszik");
        }

        public override void Eszik()
        {
            Console.WriteLine("A sportoló sokat eszik, hasznos ételeket");
        }

        public override void Iszik()
        {
            Console.WriteLine("A sportoló sportitalt iszik");
        }

        public override void Mozog()
        {
            Console.WriteLine("A sportoló lendületesen mozog");
        }

        public void Sport()
        {
            Console.WriteLine($"A sportoló sportol {Sportag}");
        }
    }
}
