using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emberek_ABS
{
    public class Nyugdijas : Ember
       
    {
        public int Munkaviszony { get; set; }

        public override void Alszik()
        {
            Console.WriteLine("A nyugdíjas keveset alszik");
        }

        public override void Eszik()
        {
            Console.WriteLine("A nyugdíjas keveset eszik");
        }

        public override void Iszik()
        {
            Console.WriteLine("A nyugdíjas vizet is iszik");
        }

        public override void Mozog()
        {
            Console.WriteLine("Megfontoltan mozog");
        }

        public void Piac()
        {
            Console.WriteLine("Piacra megy");
        }

    }
}
