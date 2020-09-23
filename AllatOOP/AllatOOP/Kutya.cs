using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatOOP
{
    public class Kutya:Allat
    {
        private string fajta;
        private int marmagassag;

        public Kutya(string fajta,int marmagassag,string nev,int suly):base(nev,suly)
        {
            this.fajta = fajta;
            this.marmagassag = marmagassag;
            
        }

        public void Ugat()
        {
            Console.WriteLine("A kutya ugat");
        }

        public override void Eszik()
        {
            Console.WriteLine("A kutya habzsolva eszik");
        }

        public override void Mozog()
        {
            Console.WriteLine("A kutya fut");
        }

        public override string ToString()
        {
            return $"{fajta},{marmagassag},{GetNev()}";
        }
    }
}
